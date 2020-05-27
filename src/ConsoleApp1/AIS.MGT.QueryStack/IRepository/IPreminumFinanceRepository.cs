using AIS.MGT.QueryStack.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AIS.MGT.QueryStack.IRepository
{
    public interface IPreminumFinanceRepository
    {
        Task<IEnumerable<dynamic>> GetStateByVersionId(int versionId);

        Task AddState(List<StateInfo> stateInfos, int id_version);

        Task<IEnumerable<StateDrop>> GetStateDrop();

        Task<IEnumerable<AgencyTemp>> GetAgencies();

        Task<IEnumerable<UnitTree>> GetLobUnitsCoverageDivision();

        Task<IEnumerable<VersionInfo>> GetAllVersion();

        Task<int> GetVersionMaxOrder();

        Task<int> AddVersion(VersionInfo versionInfo);

        Task AddUnitTree(List<UnitTreeInfo> unitTreeInfos, int id_version);

        Task AddStateOrigin(IEnumerable<StateInfo> stateInfos, int id_version);

        Task<IEnumerable<UnitVersion>> GetVersionUnits(int id_version);

        Task<IEnumerable<dynamic>> GetContractTree();

        Task AddMPSubContract(IEnumerable<int> subcontracts, int id_version);

        Task AddMPContractType(IEnumerable<int> contractTypes, int id_version);

        Task AddMPPayment(IEnumerable<int> payments, int id_version);

        Task AddPFVersionAgency(IEnumerable<Guid> pf_Version_Agencies, int id_version);

        Task AddPFAgency(IEnumerable<pf_agency_info> pf_agency_infos);

        Task<IEnumerable<dynamic>> GetAgenciesByVersionId(int id_version);

        Task<IEnumerable<dynamic>> GetContractType();

        Task<IEnumerable<int>> GetMPContractTypes(int id_version);

        Task<IEnumerable<int>> GetMPPayments(int id_version);

        Task<IEnumerable<int>> GetMPSubContract(int id_version);

        Task<IEnumerable<country_states>> GetCountryStates();

        Task<IEnumerable<countries>> GetAllCountries();

        Task<IEnumerable<states>> GetStateByCountryId(int id_country);

        Task<IEnumerable<dynamic>> GetRateTableAll();

        Task<(IEnumerable<dynamic> data, int page)> GetAgencyPage(string condition, int pageSize, int pageIndex);
    }
}
