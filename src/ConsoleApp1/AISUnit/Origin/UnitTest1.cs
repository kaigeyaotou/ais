using ConsoleApp1.AISHelper;
using System;
using System.Collections.Generic;
using Xunit;

namespace AISUnit
{
    public class UnitTest1
    {

        [Fact]
        public void Getunit()
        {
            var a = new Guid("F2E4B6D4-6204-4508-997D-4A492658C831");
        }

        [Fact]
        public async void AISNewBillingUnitTest()
        {
            NewBillingArgs newBillingArgs = new NewBillingArgs()
            {
                insured = new NewBilling_insured()
                {
                    insuredCANumber = " ",
                    insuredMCNumber = " ",
                    aisAccountNumber = " ",
                    insuredId = "DEMOACCOUNT",
                    insuredName1 = "JOHN",
                    insuredName2 = "SMITH",
                    insuredAddress1 = "123 Main Street",
                    insuredAddress2 = "Apt A",
                    insuredCity = "St. Louis",
                    insuredState = "MO",
                    insuredZip = "63141",
                    insuredPhoneNumber = "3145760007",
                    insuredFaxNumber = "3148787843",
                    insuredEmail = "INSURED@AUTOMATEDINSTALLMENT.COM",
                    insuredCellPhoneServiceProviderCode = "1",
                    insuredCellPhoneNumber = "3145760007",
                    insuredBillMailOption = "E",
                    insuredBillReminderOption = "S",
                    bankAccountType = "C",
                    bankABANumber = "081009428",
                    bankAccountNumber = "12341234123412341",
                    insuredSSNFederalId = "123123123"
                },
                account = new NewBilling_account()
                {
                    brokerFeeAddonFlag = "",
                    spanishFlag = "",
                    signatureReceived = " ",
                    billingType = "",
                    accountType = "P",
                    totalPremiumAmount = "2150.00",
                    totalDownPayAmount = "650.00",
                    amountFinanced = "1500.00",
                    calculateFinanceChargeFlag = "N",
                    financeCharge = "185.40",
                    totalOfPayments = "1685.40",
                    quarterlyPaymentFlag = "N",
                    paymentTerm = "9",
                    paymentAmount = "187.27",
                    firstPaymentDate = "11012018",
                    originalAPR = "28.76",
                    currentAPR = "28.76",
                    brokerFeeAddonAmount = "0.00",
                    policyBrokerFees = "0.00",
                    paymentReceived = "0.00",
                    floridaAccountFlag = "N",
                    stampTax = "0.00",
                    quoteNumber = "0",
                    billingFee = "0.00"
                },
                agent = new NewBilling_agent()
                {
                    agentCodeCrossReference = " ",
                    agentName = " ",
                    generalAgentName = " ",
                    agentCode = "040000"
                }
            };
            var policies = new List<NewBilling_policies>();
            policies.Add(new NewBilling_policies()
            {
                policyNumber = "TESTPFPOLICY0001",
                policyInceptionDate = "10012018",
                policyTerm = 12,
                policyInsuranceCompanyCrossReference = " ",
                policyInsuranceCompanyName = " ",
                policyInsuranceCompanyCO = " ",
                policyCoverageTypeCrossReference = " ",
                policyCommissionRetainFlag = "",
                policyFee3Description = "",
                policyFee3Type = "",
                policyFee4Type = "",
                policyFee4Description = "",
                policyInsuranceCompanyNumber = "6688",
                policyCoverageTypeCode = "18",
                policyPremiumAmount = "2000.00",
                policyPremiumDownpay = "500.00",
                policyUnpaidPremiumAmount = "1500.00",
                policyCommissionAmount = "0.00",
                policyCommissionPercentage = "0.000",
                policyFee1Type = "T",
                policyFee1Description = "TAXES",
                policyFee1Amount = "50.00",
                policyFee1AmountDownpay = "50.00",
                policyFee1UnpaidAmount = "0.00",
                policyFee2Type = "F",
                policyFee2Description = "FEES",
                policyFee2Amount = "100.00",
                policyFee2AmountDownpay = "100.00",
                policyFee2UnpaidAmount = "0.00",
                policyFee3Amount = "0.00",
                policyFee3AmountDownpay = "0.00",
                policyFee3UnpaidAmount = "0.00",
                policyFee4Amount = "0.00",
                policyFee4AmountDownpay = "0.00",
                policyFee4UnpaidAmount = "0.00",
                policyFilingFlag = "N",
                policyFilingDays = "0"
            });
            newBillingArgs.policies = policies;
            HttpClientBase<IdentityModel> client = new HttpClientBase<IdentityModel>();
            var ret = await client.SetUpNewBilling(newBillingArgs);
            Assert.NotNull(ret);
        }

        [Fact]
        public void Base64EncodingUnitTest()
        {
            string code = "key123:pwd321";
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(code);
            var str = System.Convert.ToBase64String(plainTextBytes);
            Assert.Equal("a2V5MTIzOnB3ZDMyMQ==", str);
        }


        [Fact]
        public async void AdditionalPreminumEndorsementUnitTest()
        {
            AdditionalPreminumArgs additionalPreminumArgs = new AdditionalPreminumArgs()
            {
                insuredId = "DEMOACCOUNT",
                insuredName1 = "JOHN",
                aisAccountNumber = "98000001",
                note1 = "SAMPLE NOTE 01",
                note2 = "SAMPLE NOTE 02"
            };
            AdditionalPreminum_policy additionalPreminum_Policy = new AdditionalPreminum_policy()
            {
                policyNumber = "TESTPFPOLICY0001",
                policyInceptionDate = "10012018",
                policyTerm = "12",
                policyInsuranceCompanyCrossReference = "XY",
                policyInsuranceCompanyNumber = "6688",
                policyCoverageTypeCode = "18",
                policyPremiumAmount = "1000.00",
                policyPremiumDownpay = "100.00",
                policyUnpaidPremiumAmount = "900.00",
                policyCommissionAmount = "0.00",
                policyCommissionPercentage = "0.000",
                policyCommissionRetainFlag = "N",
                policyFee1Type = "T",
                policyFee1Description = "TAXES",
                policyFee1Amount = "50.00",
                policyFee1AmountDownpay = "50.00",
                policyFee2Type = "F",
                policyFee1UnpaidAmount = "0.00",
                policyFee2Description = "FEES",
                policyFee2Amount = "100.00",
                policyFee2AmountDownpay = "100.00",
                policyFee2UnpaidAmount = "0.00",
                policyFee3Amount = "0.00",
                policyFee3AmountDownpay = "0.00",
                policyFee3UnpaidAmount = "0.00",
                policyFee4Amount = "0.00",
                policyFee4AmountDownpay = "0.00",
                policyFee4UnpaidAmount = "0.00",
                policyFilingFlag = "N",
                policyFilingDays = "0",
                policyInsuranceCompanyName = " ",
                policyInsuranceCompanyCO = " ",
                policyCoverageTypeCrossReference = " ",
                policyFee3Type = " ",
                policyFee3Description = " ",
                policyFee4Type = " ",
                policyFee4Description = " "
            };

            additionalPreminumArgs.policies = new List<AdditionalPreminum_policy>() { additionalPreminum_Policy };
            HttpClientBase<AdditionalPreminum_policy> httpClientBase = new HttpClientBase<AdditionalPreminum_policy>();
            var result = await httpClientBase.AdditionalPreminum(additionalPreminumArgs);

            Assert.NotNull(result);
        }

        [Fact]
        public async void AddPreminumFinanceUnitTest()
        {
            AddPreminumFinanceArgs addPreminumFinanceArgs = new AddPreminumFinanceArgs()
            {
                insured = new AddPreminumFinance_insured()
                {
                    insuredId = " ",
                    insuredName1 = "JOHN",
                    insuredName2 = "SMITH",
                    insuredAddress1 = "123 Main Street",
                    insuredAddress2 = "Apt A",
                    insuredCity = "St. Louis",
                    insuredState = "MO",
                    insuredZip = "63141",
                    insuredPhoneNumber = "3145760007",
                    insuredEmail = "INSURED@AUTOMATEDINSTALLMENT.COM"
                },
                agent = new AddPreminumFinance_agent()
                {
                    agentCodeCrossReference = " ",
                    agentName = " ",
                    agentCode = "040000"
                },
                account = new AddPreminumFinance_account()
                {
                    brokerFeeAddonFlag = " ",
                    billingType = " ",
                    accountType = "C",
                    totalPremiumAmount = "2150.00",
                    totalDownPayAmount = "650.00",
                    amountFinanced = "1500.00",
                    calculateFinanceChargeFlag = "N",
                    financeCharge = "185.40",
                    totalOfPayments = "1685.40",
                    quarterlyPaymentFlag = "N",
                    paymentTerm = "9",
                    paymentAmount = "187.27",
                    firstPaymentDate = "11012018",
                    originalAPR = "28.76",
                    currentAPR = "28.76",
                    quoteUser = "666000000999",
                    brokerFeeAddonAmount = "0.00",
                    policyBrokerFees = "0.00",
                    floridaAccountFlag = "N",
                    stampTax = "0.00",
                    quoteNumber = "0",
                    billingFee = "0.00"
                }
            };

            List<AddPreminumFinance_policy> policys = new List<AddPreminumFinance_policy>() { };
            policys.Add(new AddPreminumFinance_policy()
            {
                policyNumber = "TESTQ02POLICY0001",
                policyInceptionDate = "10012018",
                policyTerm = 12,
                policyInsuranceCompanyCrossReference = "",
                policyCoverageTypeCrossReference = "",
                policyFee3Type = "",
                policyFee3Description = "",
                policyFee4Type = "",
                policyFee4Description = "",
                policyInsuranceCompanyNumber = "6688",
                policyCoverageTypeCode = "18",
                policyPremiumAmount = "2000.00",
                policyPremiumDownpay = "500.00",
                policyFee1Type = "T",
                policyFee1Description = "TAXES",
                policyFee1Amount = "50.00",
                policyFee1AmountDownpay = "50.00",
                policyFee2Type = "F",
                policyFee2Description = "FEES",
                policyFee2Amount = "100.00",
                policyFee2AmountDownpay = "100.00",
                policyFee3Amount = "0.00",
                policyFee3AmountDownpay = "0.00",
                policyFee4Amount = "0.00",
                policyFee4AmountDownpay = "0.00",
                policyFilingFlag = "N",
                policyFilingDays = "0"
            });

            addPreminumFinanceArgs.policies = policys;
            HttpClientBase<AddPreminumFinance_policy> httpClientBase = new HttpClientBase<AddPreminumFinance_policy>();
            var result = await httpClientBase.AddPreminumFinance(addPreminumFinanceArgs);

            Assert.NotNull(result);
        }

        [Fact]
        public async void GetBillingAccountInformationUnitTest()
        {
            BillingAccountInformationArgs billingAccountInformationArgs = new BillingAccountInformationArgs()
            {
                aisAccountNumber = "98000001",
                insuredId = "DEMOACCOUNT",
                policyNumber = "TESTPFPOLICY0001",
                policyFlag = "Y"
            };

            HttpClientBase<BillingAccountInformationArgs> httpClientBase = new HttpClientBase<BillingAccountInformationArgs>();

            var result = await httpClientBase.GetBillingAccountInformation(billingAccountInformationArgs);

            Assert.NotNull(result);
        }

        [Fact]
        public async void ReturnPreminumEndorsementUnitTest()
        {
            ReturnPreminumEndorsementArgs returnPreminumEndorsementArgs = new ReturnPreminumEndorsementArgs()
            {
                insuredId = "DEMOACCOUNT",
                insuredName1 = "JOHN",
                aisAccountNumber = "98000001",
                note1 = "SAMPLE NOTE 01",
                note2 = "SAMPLE NOTE 02"

            };

            returnPreminumEndorsementArgs.policies = new List<ReturnPreminumEndorsement_policy>() {
            new ReturnPreminumEndorsement_policy(){
            policyNumber="TESTPFPOLICY0001",
            policyReturnPremiumAmount="1000.00"
            }
            };

            HttpClientBase<ReturnPreminumEndorsement_policy> httpClientBase = new HttpClientBase<ReturnPreminumEndorsement_policy>();

            var result = await httpClientBase.ReturnPreminumEndorsement(returnPreminumEndorsementArgs);

            Assert.NotNull(result);
        }


        [Fact]
        public async void PolicyCancellationUnitTest()
        {
            PolicyCancellationArgs policyCancellationArgs = new PolicyCancellationArgs()
            {
                insuredId = "DEMOACCOUNT",
                aisAccountNumber = "98000001",
                note1 = "SAMPLE NOTE 01",
                note2 = "SAMPLE NOTE 02",
                agentCode = "040000",
                agentCodeCrossReference = " ",
                cancellationDate = "10012018",
                cancellationType = "P",
                requestedBy = "I",
                policies = new List<PolicyCancellation_policy>() {
                new PolicyCancellation_policy(){
                policyNumber="TESTPFPOLICY0001"
                }
                }
            };

            HttpClientBase<PolicyCancellation_policy> httpClientBase = new HttpClientBase<PolicyCancellation_policy>();

            var result = await httpClientBase.PolicyCancellation(policyCancellationArgs);

            Assert.NotNull(result);
        }

        [Fact]
        public async void PolicyReinStatementUnitTest()
        {
            PolicyReinStatementArgs policyReinStatementArgs = new PolicyReinStatementArgs()
            {
                insuredId = "DEMOACCOUNT",
                aisAccountNumber = "98000001",
                note1 = "SAMPLE NOTE 01",
                note2 = "SAMPLE NOTE 02",
                agentCode = "040000",
                reinstateDate = "10012018",
                agentCodeCrossReference = " ",
                reinstateType = "P",
                requestedBy = "I",
                policies = new List<PolicyReinStatement_policy>() {
                new PolicyReinStatement_policy(){
                policyNumber="TESTPFPOLICY0001"
                }
                }
            };

            HttpClientBase<PolicyReinStatement_policy> httpClientBase = new HttpClientBase<PolicyReinStatement_policy>();

            var result = await httpClientBase.PolicyReinStatement(policyReinStatementArgs);
            Assert.NotNull(result);
        }

        [Fact]
        public async void InsuredInformationChangeUnitTest()
        {
            InsuredInformationChangeArg insuredInformationChangeArg = new InsuredInformationChangeArg()
            {
                insuredInfo = new InsuredInformationChange_insuredInfo()
                {
                    insuredId = "DEMOACCOUNT",
                    aisAccountNumber = "98000001",
                    insuredNameChangeFlag = "N",
                    insuredAddressChangeFlag = "Y",
                    insuredAddress1 = "955 Executive Parkway Drive",
                    insuredAddress2 = "Suite 216",
                    insuredCity = "St. Louis",
                    insuredState = "MO",
                    insuredName1 = "",
                    insuredName2 = "",
                    insuredPhoneNumber = "",
                    insuredFaxNumber = "",
                    insuredEmail = "",
                    insuredCellPhoneServiceProviderCode = "",
                    insuredCellPhoneNumber = "",
                    insuredBillMailOption = "",
                    insuredBillReminderOption = "",
                    insuredZip = "63141",
                    insuredPhoneChangeFlag = "N",
                    insuredFaxChangeFlag = "N",
                    insuredEmailChangeFlag = "N",
                    insuredCellPhoneChangeFlag = "N",
                    insuredBillMailOptionChangeFlag = "N",
                    insuredBillReminderOptionChangeFlag = "N"
                }
            };

            HttpClientBase<InsuredInformationChange_insuredInfo> httpClientBase = new HttpClientBase<InsuredInformationChange_insuredInfo>();

            var result = await httpClientBase.InsuredInformationChange(insuredInformationChangeArg);

            Assert.NotNull(result);
        }

        [Fact]
        public async void AgentInformationChangeUnitTest()
        {
            AgentInformationChangeArgs agentInformationChangeArgs = new AgentInformationChangeArgs()
            {
                agentInfo = new AgentInformationChange_agentinfo()
                {
                    agentCode = "040999",
                    agentRequestType = "C",
                    agentNameChangeFlag = "N",
                    agentAddressChangeFlag = "Y",
                    agentAddress = "123 Main Street",
                    agentCity = "New York",
                    agentState = "NY",
                    agentZipCode = "10001",
                    agentCodeCrossReference = " ",
                    agentName = " ",
                    agentPhoneNumber = "",
                    agentFaxNumber = "",
                    agentEmailAddress = "",
                    agentSSNFederalIdTypeFlag = "",
                    agentSSNFederalId = "",
                    agentMailOptionFlag = "",
                    agentPhoneChangeFlag = "N",
                    agentFaxChangeFlag = "N",
                    agentEmailChangeFlag = "N",
                    agentMailOptionChangeFlag = "N",
                    agentSSNFederalIdChangeFlag = "N"
                }
            };

            HttpClientBase<AgentInformationChange_agentinfo> httpClientBase = new HttpClientBase<AgentInformationChange_agentinfo>();
            var result = await httpClientBase.AgentInformationChange(agentInformationChangeArgs);

            Assert.NotNull(result);
        }
    }
}
