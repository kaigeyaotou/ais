using AIS.MGT.QueryStack.IRepository;
using AIS.MGT.QueryStack.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AIS.MGT.QueryStack.SqlServer.Repository
{
    public class PreminumFinanceRepository : IPreminumFinanceRepository
    {
        public PreminumFinanceRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        private IDbConnection dbConnection { get; set; }
        public async Task<IEnumerable<dynamic>> GetStateByVersionId(int versionId)
        {
            string sql = string.Format($@"SELECT
	a.id_state,
	a.state_id,
	a.license,
	a.effective_date,
	a.expiration_date,
	a.hasexpiration,
	b.state_abbr 
FROM
	pf_state a
	INNER JOIN states b ON a.state_id= b.id_state
	INNER JOIN pf_version_state c ON c.id_state = a.id_state 
WHERE
	c.id_version= @versionId 
	AND a.deleted=0");

            return await dbConnection.QueryAsync<dynamic>(sql, new { versionId });
        }

        public async Task<IEnumerable<StateDrop>> GetStateDrop()
        {
            string sql = string.Format($@"SELECT
	id_state StateId,
	id_country CountryId,
	state_abbr Abbr,
	state_name StateName 
FROM
	states");

            return await dbConnection.QueryAsync<StateDrop>(sql);
        }

        public async Task<IEnumerable<AgencyTemp>> GetAgencies()
        {
            string sql = string.Format($@"SELECT NAME AgencyName,
	'n' PreminumFinance,
	'A' RateTable,
	'dba' DBA,
	'website' WebSite,
	phone_number AgencyPhone,
	partner PARTNER,
	id_agency AgencyID,
	MASTER MASTER,
	'typeofentity' TypeOfEntity,
	'subtype' SubType,
	addr1 Address,
	city City,
	id_country Country,
	id_state State,
	zip Zip,
	agreement_status STATUS,
	date_created DateCreated 
FROM
	agencies");

            string sqlte = string.Format($@"SELECT a.NAME AgencyName,
	'n' PreminumFinance,
	'A' RateTable,
	b.name DBA,
	'website' WebSite,
	a.phone_number AgencyPhone,
	a.partner PARTNER,
	a.id_agency AgencyID,
	a.MASTER MASTER,
	b.type_of_entity TypeOfEntity,
	'subtype' SubType,
	a.addr1 Address,
	a.city City,
	d.country_name Country,
	c.state_name State,
	a.zip Zip,
	a.agreement_status STATUS,
	a.date_created DateCreated 
FROM
	agencies a left join agency_dba b 
	on a.id_agency=b.id_agency
	inner join states c on c.id_state=a.id_state
	inner join countries d on d.id_country=a.id_country");

            return await dbConnection.QueryAsync<AgencyTemp>(sqlte);
        }

        public async Task<IEnumerable<UnitTree>> GetLobUnitsCoverageDivision()
        {
            string sql = string.Format($@"
SELECT
	b.id_division_product,
	a.id_division,
	c.id_product,
	e.id_lob,
	d.id_coverage,
	a.division_name,
	c.product_name,
	d.coverage_name ,
	e.lob_name 
FROM
	division a
	INNER JOIN division_lob_coverage_product b ON a.id_division= b.id_division
	INNER JOIN products c ON c.id_product= b.id_product
	INNER JOIN coverage d ON d.id_coverage= b.id_coverage
	INNER JOIN lob e ON e.id_lob= b.id_lob
");

            return await dbConnection.QueryAsync<UnitTree>(sql);
        }

        public async Task<IEnumerable<VersionInfo>> GetAllVersion()
        {
            string sql = string.Format($@"SELECT
	id_version,
	date_created,
	eff_date,
	ord 
FROM
	pf_version 
WHERE
	deleted =0");

            return await dbConnection.QueryAsync<VersionInfo>(sql);
        }

        public async Task AddState(List<StateInfo> stateInfos, int id_version)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {
                List<Guid> id_states = new List<Guid>();
                foreach (var item in stateInfos)
                {
                    id_states.Add(Guid.NewGuid());
                }

                string sql = string.Format($@"
INSERT INTO pf_state (id_state, state_id, license, effective_date, expiration_date, hasexpiration, deleted )
VALUES
	(@id_state, @state_id, @license, @effective_date, @expiration_date, @hasexpiration, 0 )
");

                var paramaters_state = new List<DynamicParameters>();
                for (int i = 0; i < stateInfos.Count; i++)
                {
                    var item = stateInfos[i];
                    var param = new DynamicParameters();
                    param.Add("id_state", id_states[i]);
                    param.Add("state_id", item.state_id);
                    param.Add("license", item.license);
                    param.Add("effective_date", item.effective_date);
                    param.Add("expiration_date", item.expiration_date);
                    param.Add("hasexpiration", item.hasexpiration);
                    paramaters_state.Add(param);
                }
                await dbConnection.ExecuteAsync(sql, paramaters_state, tran);
                //tran.Commit();
                // add relation
                string sql_relation = string.Format($@"
INSERT INTO pf_version_state ( id_version, id_state, created_date, deleted )
VALUES
	( @id_version,@id_state, GETDATE( ), 0 )
");

                var paramater_relation = new List<DynamicParameters>();
                foreach (var item in id_states)
                {
                    var param = new DynamicParameters();
                    param.Add("id_version", id_version);
                    param.Add("id_state", item);
                    paramater_relation.Add(param);
                }

                await dbConnection.ExecuteAsync(sql_relation, paramater_relation, tran);

                tran.Commit();

                dbConnection.Close();
                tran.Dispose();
            }
        }

        public async Task<int> GetVersionMaxOrder()
        {
            string sql = string.Format($@"SELECT MAX
	( ord ) 
FROM
	pf_version 
WHERE
	deleted =0");

            return await dbConnection.QueryFirstOrDefaultAsync<int>(sql);

        }

        public async Task<int> AddVersion(VersionInfo versionInfo)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {

                string sql = string.Format($@"INSERT INTO pf_version ( date_created, eff_date, deleted, ord )
VALUES
	( GETDATE( ),@eff_date, 0,@ord );
SELECT
	SCOPE_IDENTITY( )");

                var result = await dbConnection.QueryFirstOrDefaultAsync<int>(sql, new { versionInfo.eff_date, versionInfo.ord }, transaction: tran);

                tran.Commit();

                dbConnection.Close();
                tran.Dispose();

                return result;
            }
        }

        public async Task AddUnitTree(List<UnitTreeInfo> unitTreeInfos, int id_version)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {
                if (unitTreeInfos.Any())
                {
                    List<Guid> id_units = new List<Guid>();
                    foreach (var item in unitTreeInfos)
                    {
                        id_units.Add(Guid.NewGuid());
                    }
                    StringBuilder sb = new StringBuilder();
                    var paramaters = new List<DynamicParameters>();
                    sb.Append($@"INSERT INTO pf_unittree ( id_unittree,id_division_product, deleted, created_date )
VALUES
	(@id_unittree, @id_division_product, 0, GETDATE( ) )");
                    for (int i = 0; i < unitTreeInfos.Count(); i++)
                    {
                        var param = new DynamicParameters();
                        param.Add("id_unittree", id_units[i]);
                        param.Add("id_division_product", unitTreeInfos[i].id_division_product);
                        paramaters.Add(param);
                    }

                    string sql_relation = string.Format($@"INSERT INTO pf_version_unit ( id_version, id_unit, created_date, deleted )
VALUES
	( @id_version, @id_unit, GETDATE( ), 0 )
");

                    List<DynamicParameters> paramaters_relation = new List<DynamicParameters>();
                    foreach (var item in id_units)
                    {
                        var param = new DynamicParameters();
                        param.Add("id_version", id_version);
                        param.Add("id_unit", item);
                        paramaters_relation.Add(param);
                    }

                    await dbConnection.ExecuteAsync(sql_relation, paramaters_relation, transaction: tran);


                    await dbConnection.ExecuteAsync(sb.ToString(), paramaters, transaction: tran);

                    tran.Commit();

                    dbConnection.Close();
                    tran.Dispose();
                }
            }
        }

        public async Task AddStateOrigin(IEnumerable<StateInfo> stateInfos, int id_version)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {
                string sql_relation = string.Format($@"
INSERT INTO pf_version_state ( id_version, id_state, created_date, deleted )
VALUES
	( @id_version,@id_state, GETDATE( ), 0 )
");
                var paramater_state = new List<DynamicParameters>();
                foreach (var item in stateInfos)
                {
                    var param = new DynamicParameters();
                    param.Add("id_version", id_version);
                    param.Add("id_state", item.id_state);
                    paramater_state.Add(param);
                }

                await dbConnection.ExecuteAsync(sql_relation, paramater_state, tran);

                tran.Commit();

                dbConnection.Close();
                tran.Dispose();
            }
        }

        public async Task<IEnumerable<UnitVersion>> GetVersionUnits(int id_version)
        {
            string sql = string.Format($@"SELECT
	a.id_unit,
	b.id_division_product 
FROM
	pf_version_unit a
	INNER JOIN pf_unittree b ON a.id_unit= b.id_unittree 
WHERE
	a.deleted= 0 
	AND b.deleted= 0 
	AND a.id_version=@id_version
");

            return await dbConnection.QueryAsync<UnitVersion>(sql, new { id_version });
        }

        public async Task<IEnumerable<Guid>> AddAgency(List<agency_version> agency_Versions)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {

                StringBuilder sb = new StringBuilder();
                sb.Append($@"INSERT INTO pf_agency ( id_agency, agency_id, rate_id, has_pf, deleted, create_date )
VALUES
	( @id_agency,@agency_id,@rate_id, 1, 0, GETDATE( ) )");

                var ids = new List<Guid>();
                foreach (var item in agency_Versions)
                {
                    ids.Add(Guid.NewGuid());
                }

                var paramaters = new List<DynamicParameters>();
                for (int i = 0; i < agency_Versions.Count(); i++)
                {
                    var param = new DynamicParameters();
                    param.Add("id_agency", ids[i]);
                    param.Add("agency_id", agency_Versions[i].agency_id);
                    param.Add("rate_id", agency_Versions[i].rate_id);

                    paramaters.Add(param);
                }

                await dbConnection.ExecuteAsync(sb.ToString(), paramaters, tran);

                tran.Commit();
                dbConnection.Close();
                return ids;
            }
        }

        public async Task AddVersionAgency(IEnumerable<Guid> ids, int version_id)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {

                StringBuilder sb = new StringBuilder();
                sb.Append($@"INSERT INTO pf_version_agency ( id_version, id_agency, deleted, created_date )
VALUES
	( @id_version, @id_agency, 0, GETDATE() )");

                var paramaters = new List<DynamicParameters>();
                foreach (var item in ids)
                {
                    var param = new DynamicParameters();
                    param.Add("id_version", version_id);
                    param.Add("id_agency", item);
                    paramaters.Add(param);
                }
                await dbConnection.ExecuteAsync(sb.ToString(), paramaters, tran);

                tran.Commit();

                dbConnection.Close();
            }
        }

        public async Task<IEnumerable<dynamic>> GetContractTree()
        {
            string sql = string.Format($@"SELECT
	a.id_contract_ooi subcontract_id,
	a.id_contract,
	a.name subcontract_name,
	b.contract_name,
	c.name bp_name,
	c.id_bp 
FROM
	contract_ooi_rel a
	INNER JOIN contract b ON a.id_contract = b.id_contract
	INNER JOIN brokers c ON b.id_bp= c.id_bp");

            return await dbConnection.QueryAsync<dynamic>(sql);
        }

        public async Task AddMPPayment(IEnumerable<int> payments, int id_version)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {
                string sql = string.Format($@"INSERT INTO pf_version_mp_payment ( id_version, id_payment, created_date, deleted )
VALUES
	( @id_version, @id_payment, GETDATE( ), 0 )");

                var paramaters = new List<DynamicParameters>();
                foreach (var item in payments)
                {
                    var param = new DynamicParameters();
                    param.Add("id_version", id_version);
                    param.Add("id_payment", item);
                    paramaters.Add(param);
                }

                await dbConnection.ExecuteAsync(sql, paramaters, tran);

                tran.Commit();
                dbConnection.Close();
            }

        }

        public async Task AddMPContractType(IEnumerable<int> contractTypes, int id_version)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {
                string sql = string.Format($@"
INSERT INTO pf_version_mp_contract_type ( id_contract_type, id_version, created_date, deleted )
VALUES
	( @id_contract_type, @id_version, GETDATE(), 0 )");

                var paramaters = new List<DynamicParameters>();
                foreach (var item in contractTypes)
                {
                    var param = new DynamicParameters();
                    param.Add("id_contract_type", item);
                    param.Add("id_version", id_version);

                    paramaters.Add(param);
                }

                await dbConnection.ExecuteAsync(sql, paramaters, tran);
                tran.Commit();
                dbConnection.Close();
            }

        }

        public async Task AddMPSubContract(IEnumerable<int> subcontracts, int id_version)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {
                string sql = string.Format($@"INSERT INTO pf_version_mp_subcontract ( id_version, id_mp_subcontract, created_date, deleted )
VALUES
	( @id_version, @id_mp_subcontract, GETDATE( ), 0 )");

                var paramaters = new List<DynamicParameters>();
                foreach (var item in subcontracts)
                {
                    var param = new DynamicParameters();
                    param.Add("id_version", id_version);
                    param.Add("id_mp_subcontract", item);

                    paramaters.Add(param);
                }

                await dbConnection.ExecuteAsync(sql, paramaters, tran);

                tran.Commit();
                dbConnection.Close();
            }

        }

        public async Task AddPFVersionAgency(IEnumerable<Guid> agencyIds, int id_version)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {
                string sql = string.Format($@"INSERT INTO pf_version_agency ( id_version, id_agency, deleted, created_date )
VALUES
	( @id_version, @id_agency, 0, GETDATE( ) )");

                var paramaters = new List<DynamicParameters>();
                foreach (var item in agencyIds)
                {
                    var param = new DynamicParameters();
                    param.Add("id_version", id_version);
                    param.Add("id_agency", item);

                    paramaters.Add(param);
                }

                await dbConnection.ExecuteAsync(sql, paramaters, tran);
                tran.Commit();
                dbConnection.Close();
            }

        }

        public async Task AddPFAgency(IEnumerable<pf_agency_info> pf_agency_infos)
        {
            dbConnection.Open();
            using (var tran = dbConnection.BeginTransaction())
            {
                string sql = string.Format($@"INSERT INTO pf_agency ( id_agency, agency_id, rate_id, has_pf, deleted, created_date )
VALUES
	( @id_agency, @agency_id, @rate_id, @has_pf, 0, GETDATE() )");

                var paramaters = new List<DynamicParameters>();
                foreach (var item in pf_agency_infos)
                {
                    var param = new DynamicParameters();
                    param.Add("id_agency", item.id_agency);
                    param.Add("agency_id", item.agency_id);
                    param.Add("rate_id", item.rate_id);
                    param.Add("has_pf", item.has_pf);

                    paramaters.Add(param);
                }

                await dbConnection.ExecuteAsync(sql, paramaters, tran);
                tran.Commit();
                dbConnection.Close();
            }

        }

        public async Task<IEnumerable<dynamic>> GetAgenciesByVersionId(int id_version)
        {
            string sql = string.Format($@"SELECT
	b.agency_id,
	a.id_version,
	b.has_pf,
	b.rate_id 
FROM
	pf_version_agency a
	INNER JOIN pf_agency b ON a.id_agency= b.id_agency 
WHERE
	a.id_version= @id_version 
	AND a.deleted= 0 
	AND b.deleted=0");
            return await dbConnection.QueryAsync<dynamic>(sql, new { id_version });
        }

        public async Task<IEnumerable<dynamic>> GetContractType()
        {
            string sql = string.Format($@"SELECT
	                                        id_contract_type,
	                                        name 
                                        FROM
	                                        contract_type");

            return await dbConnection.QueryAsync<dynamic>(sql);
        }

        public async Task<IEnumerable<int>> GetMPSubContract(int id_version)
        {
            string sql = string.Format($@"SELECT
	a.id_mp_subcontract 
FROM
	pf_version_mp_subcontract a
	INNER JOIN pf_version b ON a.id_version= b.id_version 
WHERE
	a.deleted= 0 
	AND b.deleted= 0 
	AND a.id_version=@id_version");

            return await dbConnection.QueryAsync<int>(sql, new { id_version });
        }

        public async Task<IEnumerable<int>> GetMPPayments(int id_version)
        {
            string sql = string.Format($@"SELECT
	a.id_payment 
FROM
	pf_version_mp_payment a
	INNER JOIN pf_version b ON a.id_version= b.id_version 
WHERE
	a.deleted= 0 
	AND b.deleted= 0 
	AND a.id_version=@id_version");

            return await dbConnection.QueryAsync<int>(sql, new { id_version });
        }

        public async Task<IEnumerable<int>> GetMPContractTypes(int id_version)
        {
            string sql = string.Format($@"SELECT
	id_contract_type 
FROM
	pf_version_mp_contract_type a
	INNER JOIN pf_version b ON a.id_version = b.id_version 
WHERE
	a.deleted= 0 
	AND b.deleted= 0 
	AND a.id_version=@id_version
");
            var result = await dbConnection.QueryAsync<int>(sql, new { id_version });
            //if (result.Any(a => a == 0))
            //{
            //    return result.Where(a => a == 0);
            //}
            //else
            //{
            //    return result;
            //}
            return result;
        }

        public async Task<IEnumerable<country_states>> GetCountryStates()
        {
            string sql = string.Format($@"SELECT
	a.id_state,
	a.state_abbr,
	a.state_name,
	b.id_country,
	b.country_abbr,
	b.country_name 
FROM
	states a
	INNER JOIN countries b ON b.id_country= a.id_country
");
            return await dbConnection.QueryAsync<country_states>(sql);

        }

        public async Task<IEnumerable<countries>> GetAllCountries()
        {
            string sql = string.Format($@"
                                SELECT
	                                id_country,
	                                country_abbr,
	                                country_name 
                                FROM
	                                countries
                                ");

            return await dbConnection.QueryAsync<countries>(sql);
        }

        public async Task<IEnumerable<states>> GetStateByCountryId(int id_country)
        {
            string sql = string.Format($@"SELECT
	a.id_state,
	a.state_abbr,
	a.state_name
FROM
	states a
	INNER JOIN countries b ON b.id_country= a.id_country
	where a.id_country=@id_country");

            return await dbConnection.QueryAsync<states>(sql, new { id_country });
        }

        public async Task<IEnumerable<dynamic>> GetRateTableAll()
        {
            string sql = string.Format($@"SELECT
	id_ratetable,
	ratetable_name 
FROM
	pf_ratetable 
WHERE
	deleted =0");

            return await dbConnection.QueryAsync<dynamic>(sql);
        }

        public async Task<(IEnumerable<dynamic> data, int page)> GetAgencyPage(int id_version, string condition, int pageSize, int pageIndex)
        {
            string page = string.Format($@" AND rownum BETWEEN {(pageIndex - 1) * pageSize} 
	AND {pageIndex * pageSize} ");
            string sql_origin = string.Format($@"SELECT
	* 
FROM
	(
	SELECT
		*,
		ROW_NUMBER ( ) OVER ( ORDER BY AgencyName ) AS rownum 
	FROM
		(
		SELECT
			a.id_agency,
			a.NAME AgencyName,
			CASE
				ISNULL( e.has_pf, NULL ) 
				WHEN 1 THEN
				'Y' ELSE 'N' 
			END PreminumFinance,
			f.ratetable_name RateTable,
			b.name DBA,
			'website' WebSite,
			a.phone_number AgencyPhone,
			a.partner PARTNER,
			a.id_agency AgencyID,
			a.MASTER MASTER,
			b.type_of_entity TypeOfEntity,
			'subtype' SubType,
			a.addr1 Address,
			d.id_country,
			c.id_state,
			e.has_pf,
			f.id_ratetable,
			f.ratetable_name,
			a.city City,
			d.country_name Country,
			c.state_name State,
			a.zip Zip,
			a.agreement_status STATUS,
			a.date_created DateCreated,
			a.date_created 
		FROM
			agencies a
			LEFT JOIN agency_dba b ON a.id_agency= b.id_agency
			LEFT JOIN states c ON c.id_state= a.id_state
			LEFT JOIN countries d ON d.id_country= a.id_country
			LEFT JOIN pf_agency e ON e.agency_id= a.id_agency
			LEFT JOIN pf_ratetable f ON f.id_ratetable= e.rate_id 
            LEFT JOIN ( SELECT * FROM pf_version_agency WHERE id_version = @id_version ) g ON g.id_agency= e.id_agency 
		) t 
	) agnecy 
WHERE
	1 =1

");
            string sql = string.Format($@"{sql_origin}     {page}
{condition}");
            string count_sql = string.Format($@" SELECT
    Count(id_agency)
FROM
    (
    SELECT
        *,
        ROW_NUMBER() OVER(ORDER BY AgencyName) AS rownum

    FROM
        (
        SELECT

            a.id_agency,
            a.NAME AgencyName,
            CASE

                ISNULL(e.has_pf, NULL)

                WHEN 1 THEN

                'Y' ELSE 'N'

            END PreminumFinance,
            f.ratetable_name RateTable,
            b.name DBA,
            'website' WebSite,
            a.phone_number AgencyPhone,
            a.partner PARTNER,
            a.id_agency AgencyID,
            a.MASTER MASTER,
            b.type_of_entity TypeOfEntity,
            'subtype' SubType,
            a.addr1 Address,
            d.id_country,
            c.id_state,
            e.has_pf,
            f.id_ratetable,
            f.ratetable_name,
            a.city City,
            d.country_name Country,
            c.state_name State,
            a.zip Zip,
            a.agreement_status STATUS,
            a.date_created DateCreated,
            a.date_created

        FROM

            agencies a

            LEFT JOIN agency_dba b ON a.id_agency = b.id_agency

            LEFT JOIN states c ON c.id_state = a.id_state

            LEFT JOIN countries d ON d.id_country = a.id_country

            LEFT JOIN pf_agency e ON e.agency_id = a.id_agency

            LEFT JOIN pf_ratetable f ON f.id_ratetable = e.rate_id
            LEFT JOIN(SELECT * FROM pf_version_agency WHERE id_version = @id_version) g ON g.id_agency = e.id_agency
        ) t
    ) agnecy
WHERE

    1 = 1

 {condition}");

            string sqltotal = $"{sql};{count_sql}";

            var result = await dbConnection.QueryMultipleAsync(sqltotal, new { id_version });
            var data = await result.ReadAsync<dynamic>();
            var count = await result.ReadSingleAsync<int>();

            return (data, count);
        }
    }


}
