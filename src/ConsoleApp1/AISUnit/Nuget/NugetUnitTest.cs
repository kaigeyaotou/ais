using Dapper;
using MGT.AIS.Client;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AISUnit.Nuget
{
    public class NugetUnitTest
    {
        [Fact]
        public void ConfigTest()
        {
            var dir = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("E:\\source code\\aisapi\\ConsoleApp1\\AISUnit\\appSettings.json");
            var config = builder.Build();
            var aaa = System.Configuration.ConfigurationManager.AppSettings["AisUri"];
            var uri = config.GetSection("AisUri");
            Assert.NotNull(config);
        }

        [Fact]
        public async void AdditionalPremiumEndorsementAsyncUnitTest()
        {
            AdditionalPremiumEndorsementCommand additionalPreminumArgs = new AdditionalPremiumEndorsementCommand()
            {
                InsuredId = "DEMOACCOUNT",
                InsuredName1 = "JOHN",
                AisAccountNumber = "98000001",
                Note1 = "SAMPLE NOTE 01",
                Note2 = "SAMPLE NOTE 02"
            };
            AdditionalPreminum_policy additionalPreminum_Policy = new AdditionalPreminum_policy()
            {
                PolicyNumber = "TESTPFPOLICY0001",
                PolicyInceptionDate = "10012018",
                PolicyTerm = "12",
                PolicyInsuranceCompanyCrossReference = "XY",
                PolicyInsuranceCompanyNumber = "6688",
                PolicyCoverageTypeCode = "18",
                PolicyPremiumAmount = "1000.00",
                PolicyPremiumDownpay = "100.00",
                PolicyUnpaidPremiumAmount = "900.00",
                PolicyCommissionAmount = "0.00",
                PolicyCommissionPercentage = "0.000",
                PolicyCommissionRetainFlag = "N",
                PolicyFee1Type = "T",
                PolicyFee1Description = "TAXES",
                PolicyFee1Amount = "50.00",
                PolicyFee1AmountDownpay = "50.00",
                PolicyFee2Type = "F",
                PolicyFee1UnpaidAmount = "0.00",
                PolicyFee2Description = "FEES",
                PolicyFee2Amount = "100.00",
                PolicyFee2AmountDownpay = "100.00",
                PolicyFee2UnpaidAmount = "0.00",
                PolicyFee3Amount = "0.00",
                PolicyFee3AmountDownpay = "0.00",
                PolicyFee3UnpaidAmount = "0.00",
                PolicyFee4Amount = "0.00",
                PolicyFee4AmountDownpay = "0.00",
                PolicyFee4UnpaidAmount = "0.00",
                PolicyFilingFlag = "N",
                PolicyFilingDays = "0",
                PolicyInsuranceCompanyName = " ",
                PolicyInsuranceCompanyCO = " ",
                PolicyCoverageTypeCrossReference = " ",
                PolicyFee3Type = " ",
                PolicyFee3Description = " ",
                PolicyFee4Type = " ",
                PolicyFee4Description = " "
            };

            additionalPreminumArgs.Policies = new List<AdditionalPreminum_policy>() { additionalPreminum_Policy };

            AISClient aISClient = new AISClient("http://localhost:53713");
            var result = await aISClient.AdditionalPremiumEndorsementAsync(additionalPreminumArgs);
        }

        [Fact]
        public async void NewBillingAccountSetupUnitTest()
        {
            NewBillingAccountSetupCommand newBillingArgs = new NewBillingAccountSetupCommand()
            {
                Insured = new NewBilling_insured()
                {
                    InsuredCANumber = " ",
                    InsuredMCNumber = " ",
                    AisAccountNumber = " ",
                    InsuredId = "DEMOACCOUNT",
                    InsuredName1 = "JOHN",
                    InsuredName2 = "SMITH",
                    InsuredAddress1 = "123 Main Street",
                    InsuredAddress2 = "Apt A",
                    InsuredCity = "St. Louis",
                    InsuredState = "MO",
                    InsuredZip = "63141",
                    InsuredPhoneNumber = "3145760007",
                    InsuredFaxNumber = "3148787843",
                    InsuredEmail = "INSURED@AUTOMATEDINSTALLMENT.COM",
                    InsuredCellPhoneServiceProviderCode = "1",
                    InsuredCellPhoneNumber = "3145760007",
                    InsuredBillMailOption = "E",
                    InsuredBillReminderOption = "S",
                    BankAccountType = "C",
                    BankABANumber = "081009428",
                    BankAccountNumber = "12341234123412341",
                    InsuredSSNFederalId = "123123123"
                },
                Account = new NewBilling_account()
                {
                    BrokerFeeAddonFlag = "",
                    SpanishFlag = "",
                    SignatureReceived = " ",
                    BillingType = "",
                    AccountType = "P",
                    TotalPremiumAmount = "2150.00",
                    TotalDownPayAmount = "650.00",
                    AmountFinanced = "1500.00",
                    CalculateFinanceChargeFlag = "N",
                    FinanceCharge = "185.40",
                    TotalOfPayments = "1685.40",
                    QuarterlyPaymentFlag = "N",
                    PaymentTerm = "9",
                    PaymentAmount = "187.27",
                    FirstPaymentDate = "11012018",
                    OriginalAPR = "28.76",
                    CurrentAPR = "28.76",
                    BrokerFeeAddonAmount = "0.00",
                    PolicyBrokerFees = "0.00",
                    PaymentReceived = "0.00",
                    FloridaAccountFlag = "N",
                    StampTax = "0.00",
                    QuoteNumber = "0",
                    BillingFee = "0.00"
                },
                Agent = new NewBilling_agent()
                {
                    AgentCodeCrossReference = " ",
                    AgentName = " ",
                    GeneralAgentName = " ",
                    AgentCode = "040000"
                }
            };
            var policies = new List<NewBilling_policies>();
            policies.Add(new NewBilling_policies()
            {
                PolicyNumber = "TESTPFPOLICY0001",
                PolicyInceptionDate = "10012018",
                PolicyTerm = 12,
                PolicyInsuranceCompanyCrossReference = " ",
                PolicyInsuranceCompanyName = " ",
                PolicyInsuranceCompanyCO = " ",
                PolicyCoverageTypeCrossReference = " ",
                PolicyCommissionRetainFlag = "",
                PolicyFee3Description = "",
                PolicyFee3Type = "",
                PolicyFee4Type = "",
                PolicyFee4Description = "",
                PolicyInsuranceCompanyNumber = "6688",
                PolicyCoverageTypeCode = "18",
                PolicyPremiumAmount = "2000.00",
                PolicyPremiumDownpay = "500.00",
                PolicyUnpaidPremiumAmount = "1500.00",
                PolicyCommissionAmount = "0.00",
                PolicyCommissionPercentage = "0.000",
                PolicyFee1Type = "T",
                PolicyFee1Description = "TAXES",
                PolicyFee1Amount = "50.00",
                PolicyFee1AmountDownpay = "50.00",
                PolicyFee1UnpaidAmount = "0.00",
                PolicyFee2Type = "F",
                PolicyFee2Description = "FEES",
                PolicyFee2Amount = "100.00",
                PolicyFee2AmountDownpay = "100.00",
                PolicyFee2UnpaidAmount = "0.00",
                PolicyFee3Amount = "0.00",
                PolicyFee3AmountDownpay = "0.00",
                PolicyFee3UnpaidAmount = "0.00",
                PolicyFee4Amount = "0.00",
                PolicyFee4AmountDownpay = "0.00",
                PolicyFee4UnpaidAmount = "0.00",
                PolicyFilingFlag = "N",
                PolicyFilingDays = "0"
            });
            newBillingArgs.Policies = policies;

            AISClient aISClient = new AISClient("http://localhost:53713");
            var resut = await aISClient.NewBillingAccountSetupAsync(newBillingArgs);
        }

        [Fact]
        public async void ReturnPremiumEndorsementUnitTest()
        {
            ReturnPremiumEndorsementCommand returnPreminumEndorsementArgs = new ReturnPremiumEndorsementCommand()
            {
                InsuredId = "DEMOACCOUNT",
                InsuredName1 = "JOHN",
                AisAccountNumber = "98000001",
                Note1 = "SAMPLE NOTE 01",
                Note2 = "SAMPLE NOTE 02"

            };

            returnPreminumEndorsementArgs.Policies = new List<ReturnPreminumEndorsement_policy>() {
            new ReturnPreminumEndorsement_policy(){
            PolicyNumber="TESTPFPOLICY0001",
            PolicyReturnPremiumAmount="1000.00"
            }
            };

            AISClient aISClient = new AISClient("http://localhost:53713");
            var result = await aISClient.ReturnPremiumEndorsementAsync(returnPreminumEndorsementArgs);
            Assert.NotNull(result);
        }

        [Fact]
        public async void PolicyCancellationUnitTest()
        {
            PolicyCancellationCommand policyCancellationArgs = new PolicyCancellationCommand()
            {
                InsuredId = "DEMOACCOUNT",
                AisAccountNumber = "98000001",
                Note1 = "SAMPLE NOTE 01",
                Note2 = "SAMPLE NOTE 02",
                AgentCode = "040000",
                AgentCodeCrossReference = " ",
                CancellationDate = "10012018",
                CancellationType = "P",
                RequestedBy = "I",
                Policies = new List<PolicyCancellation_policy>() {
                new PolicyCancellation_policy(){
                PolicyNumber="TESTPFPOLICY0001"
                }
                }
            };
            AISClient aISClient = new AISClient("http://localhost:53713");
            var resut = await aISClient.PolicyCancellationAsync(policyCancellationArgs);
            Assert.NotNull(resut);
        }

        [Fact]
        public async void PolicyReinstatementUnitTest()
        {
            PolicyReinstatementCommand policyReinStatementArgs = new PolicyReinstatementCommand()
            {
                InsuredId = "DEMOACCOUNT",
                AisAccountNumber = "98000001",
                Note1 = "SAMPLE NOTE 01",
                Note2 = "SAMPLE NOTE 02",
                AgentCode = "040000",
                ReinstateDate = "10012018",
                AgentCodeCrossReference = " ",
                ReinstateType = "P",
                RequestedBy = "I",
                Policies = new List<PolicyReinStatement_policy>() {
                new PolicyReinStatement_policy(){
                PolicyNumber="TESTPFPOLICY0001"
                }
                }
            };

            AISClient aISClient = new AISClient("http://localhost:53713");
            var resut = await aISClient.PolicyReinstatementAsync(policyReinStatementArgs);
            Assert.NotNull(resut);
        }

        [Fact]
        public async void BillingAccountInformationUnitTest()
        {
            BillingAccountInformationCommand billingAccountInformationArgs = new BillingAccountInformationCommand()
            {
                AisAccountNumber = "98000001",
                InsuredId = "DEMOACCOUNT",
                PolicyNumber = "TESTPFPOLICY0001",
                PolicyFlag = "Y"
            };

            AISClient aISClient = new AISClient("http://localhost:53713");
            var resut = await aISClient.BillingAccountInformationAsync(billingAccountInformationArgs);
            Assert.NotNull(resut);
        }

        [Fact]
        public async void InsuredInformationChangeUnitTest()
        {
            InsuredInformationChangeCommand insuredInformationChangeArg = new InsuredInformationChangeCommand()
            {
                InsuredInfo = new InsuredInformationChange_insuredInfo()
                {
                    InsuredId = "DEMOACCOUNT",
                    AisAccountNumber = "98000001",
                    InsuredNameChangeFlag = "N",
                    InsuredAddressChangeFlag = "Y",
                    InsuredAddress1 = "955 Executive Parkway Drive",
                    InsuredAddress2 = "Suite 216",
                    InsuredCity = "St. Louis",
                    InsuredState = "MO",
                    InsuredName1 = "",
                    InsuredName2 = "",
                    InsuredPhoneNumber = "",
                    InsuredFaxNumber = "",
                    InsuredEmail = "",
                    InsuredCellPhoneServiceProviderCode = "",
                    InsuredCellPhoneNumber = "",
                    InsuredBillMailOption = "",
                    InsuredBillReminderOption = "",
                    InsuredZip = "63141",
                    InsuredPhoneChangeFlag = "N",
                    InsuredFaxChangeFlag = "N",
                    InsuredEmailChangeFlag = "N",
                    InsuredCellPhoneChangeFlag = "N",
                    InsuredBillMailOptionChangeFlag = "N",
                    InsuredBillReminderOptionChangeFlag = "N"
                }
            };

            AISClient aISClient = new AISClient("http://localhost:53713");
            var resut = await aISClient.InsuredInformationChangeAsync(insuredInformationChangeArg);
            Assert.NotNull(resut);
        }

        [Fact]
        public async void AgentInformationChangeUnitTest()
        {
            AgentInformationChangeCommand agentInformationChangeArgs = new AgentInformationChangeCommand()
            {
                AgentInfo = new AgentInformationChange_agentinfo()
                {
                    AgentCode = "040999",
                    AgentRequestType = "C",
                    AgentNameChangeFlag = "N",
                    AgentAddressChangeFlag = "Y",
                    AgentAddress = "123 Main Street",
                    AgentCity = "New York",
                    AgentState = "NY",
                    AgentZipCode = "10001",
                    AgentCodeCrossReference = " ",
                    AgentName = " ",
                    AgentPhoneNumber = "",
                    AgentFaxNumber = "",
                    AgentEmailAddress = "",
                    AgentSSNFederalIdTypeFlag = "",
                    AgentSSNFederalId = "",
                    AgentMailOptionFlag = "",
                    AgentPhoneChangeFlag = "N",
                    AgentFaxChangeFlag = "N",
                    AgentEmailChangeFlag = "N",
                    AgentMailOptionChangeFlag = "N",
                    AgentSSNFederalIdChangeFlag = "N"
                }
            };

            AISClient aISClient = new AISClient("http://localhost:53713");
            var resut = await aISClient.AgentInformationChangeAsync(agentInformationChangeArgs);
            Assert.NotNull(resut);
        }

        [Fact]
        public async void GeneratePremiumFinanceAgreementUnitTest()
        {
            GeneratePremiumFinanceAgreementCommand addPreminumFinanceArgs = new GeneratePremiumFinanceAgreementCommand()
            {
                Insured = new AddPreminumFinance_insured()
                {
                    InsuredId = " ",
                    InsuredName1 = "JOHN",
                    InsuredName2 = "SMITH",
                    InsuredAddress1 = "123 Main Street",
                    InsuredAddress2 = "Apt A",
                    InsuredCity = "St. Louis",
                    InsuredState = "MO",
                    InsuredZip = "63141",
                    InsuredPhoneNumber = "3145760007",
                    InsuredEmail = "INSURED@AUTOMATEDINSTALLMENT.COM"
                },
                Agent = new AddPreminumFinance_agent()
                {
                    AgentCodeCrossReference = " ",
                    AgentName = " ",
                    AgentCode = "040000"
                },
                Account = new AddPreminumFinance_account()
                {
                    BrokerFeeAddonFlag = " ",
                    BillingType = " ",
                    AccountType = "C",
                    TotalPremiumAmount = "2150.00",
                    TotalDownPayAmount = "650.00",
                    AmountFinanced = "1500.00",
                    CalculateFinanceChargeFlag = "N",
                    FinanceCharge = "185.40",
                    TotalOfPayments = "1685.40",
                    QuarterlyPaymentFlag = "N",
                    PaymentTerm = "9",
                    PaymentAmount = "187.27",
                    FirstPaymentDate = "11012018",
                    OriginalAPR = "28.76",
                    CurrentAPR = "28.76",
                    QuoteUser = "666000000999",
                    BrokerFeeAddonAmount = "0.00",
                    PolicyBrokerFees = "0.00",
                    FloridaAccountFlag = "N",
                    StampTax = "0.00",
                    QuoteNumber = "0",
                    BillingFee = "0.00"
                }
            };

            List<AddPreminumFinance_policy> policys = new List<AddPreminumFinance_policy>() { };
            policys.Add(new AddPreminumFinance_policy()
            {
                PolicyNumber = "TESTQ02POLICY0001",
                PolicyInceptionDate = "10012018",
                PolicyTerm = 12,
                PolicyInsuranceCompanyCrossReference = "",
                PolicyCoverageTypeCrossReference = "",
                PolicyFee3Type = "",
                PolicyFee3Description = "",
                PolicyFee4Type = "",
                PolicyFee4Description = "",
                PolicyInsuranceCompanyNumber = "6688",
                PolicyCoverageTypeCode = "18",
                PolicyPremiumAmount = "2000.00",
                PolicyPremiumDownpay = "500.00",
                PolicyFee1Type = "T",
                PolicyFee1Description = "TAXES",
                PolicyFee1Amount = "50.00",
                PolicyFee1AmountDownpay = "50.00",
                PolicyFee2Type = "F",
                PolicyFee2Description = "FEES",
                PolicyFee2Amount = "100.00",
                PolicyFee2AmountDownpay = "100.00",
                PolicyFee3Amount = "0.00",
                PolicyFee3AmountDownpay = "0.00",
                PolicyFee4Amount = "0.00",
                PolicyFee4AmountDownpay = "0.00",
                PolicyFilingFlag = "N",
                PolicyFilingDays = "0"
            });

            addPreminumFinanceArgs.Policies = policys;

            AISClient aISClient = new AISClient("http://localhost:53713");
            var resut = await aISClient.GeneratePremiumFinanceAgreementAsync(addPreminumFinanceArgs);

            Assert.NotNull(resut);
        }


        [Fact]
        public async void TestDB()
        {
            string connectionStr = "Data Source=localhost;port=3306;Initial Catalog=ais;user id=root;password=123456;SslMode=None;";

            using (var connection = new MySqlConnection(connectionStr))
            {
                string sql = string.Format($@"
select Id from tb_State");

                var result = await connection.QueryAsync<string>(sql);
                Assert.NotNull(result);
            }
        }
    }
}
