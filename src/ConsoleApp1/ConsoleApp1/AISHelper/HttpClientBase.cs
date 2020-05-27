using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.AISHelper
{
    public class HttpClientBase<T> where T : class, new()
    {
        public HttpClientBase() { }
        public async Task<IdentityModel> GetAccess(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic SU5LNHc2cTFmcTNEeUlaVGxkOWdhTmdmUDV3YTpCczI1dFI3UlU1TFJucXliaDBNN1RhY19PNDhh");


            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            try
            {
                HttpResponseMessage ret = new HttpResponseMessage();
                var httpContent = new FormUrlEncodedContent(param);
                ret = await httpClient.PostAsync("token", httpContent);
                if (ret.IsSuccessStatusCode)
                {
                    var temp = await ret.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<IdentityModel>(temp);
                    httpClient.DefaultRequestHeaders.Remove("Authorization");
                    return result;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<NewBilling_response> SetUpNewBilling(NewBillingArgs newBillingArgs)
        {

            var client = await GenerateHttpClient();
            string route = "/apidemo/1.0.0/services/premfin/account/new/setup";
            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(newBillingArgs), Encoding.UTF8, "application/json");
            var ret = await client.PostAsync(route, httpContent);
            if (ret.IsSuccessStatusCode)
            {
                var temp = await ret.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<NewBilling_response>(temp);
                return result;
            }
            else
            {
                var result = await ret.Content.ReadAsStringAsync();
                return null;
            }
        }

        private string GetBase64Encoding(string code)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(code);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        public async Task<BillingAccountInformation> GetBillingAccountInformation(BillingAccountInformationArgs billingAccountInformationArgs)
        {
            var client = await GenerateHttpClient();

            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(billingAccountInformationArgs), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await client.PostAsync("/apidemo/1.0.0/services/premfin/account/info/inquiry", httpContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<BillingAccountInformation>(temp);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<AddPreminumFinanceResult> AddPreminumFinance(AddPreminumFinanceArgs addPreminumFinanceArgs)
        {
            var client = await GenerateHttpClient();
            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(addPreminumFinanceArgs), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await client.PostAsync("/apidemo/1.0.0/services/premfin/quote/pfa/inquiry", httpContent);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<AddPreminumFinanceResult>(temp);
                return result;
            }
            else
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                return null;
            }
        }

        public async Task<AdditionalPreminum_result> AdditionalPreminum(AdditionalPreminumArgs additionalPreminumArgs)
        {
            var client = await GenerateHttpClient();

            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(additionalPreminumArgs), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await client.PostAsync("/apidemo/1.0.0/services/premfin/account/premium/addition", httpContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<AdditionalPreminum_result>(temp);
                return result;
            }
            else
            {
                return null;
            }
        }


        public async Task<ReturnPreminumEndorsement_result> ReturnPreminumEndorsement(ReturnPreminumEndorsementArgs returnPreminumEndorsementArgs)
        {
            var client = await GenerateHttpClient();
            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(returnPreminumEndorsementArgs), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await client.PostAsync("/apidemo/1.0.0/services/premfin/account/premium/return", httpContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ReturnPreminumEndorsement_result>(temp);
                return result;
            }
            else { return null; }
        }

        public async Task<PolicyCancellation_result> PolicyCancellation(PolicyCancellationArgs policyCancellationArgs)
        {
            var client = await GenerateHttpClient();

            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(policyCancellationArgs), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await client.PostAsync("/apidemo/1.0.0/services/premfin/account/policy/cancel", httpContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<PolicyCancellation_result>(temp);
                return result;
            }
            else { return null; }
        }

        public async Task<PolicyReinStatement_result> PolicyReinStatement(PolicyReinStatementArgs policyReinStatementArgs)
        {
            var client = await GenerateHttpClient();
            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(policyReinStatementArgs), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await client.PostAsync("/apidemo/1.0.0/services/premfin/account/policy/reinstate", httpContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<PolicyReinStatement_result>(temp);
                return result;
            }
            else { return null; }
        }


        public async Task<InsuredInformationCHnage_result> InsuredInformationChange(InsuredInformationChangeArg insuredInformationChangeArg)
        {
            var client = await GenerateHttpClient();

            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(insuredInformationChangeArg), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await client.PostAsync("/apidemo/1.0.0/services/premfin/insured/info/change", httpContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<InsuredInformationCHnage_result>(temp);
                return result;
            }
            else { return null; }
        }

        public async Task<AgentInformationChange_result> AgentInformationChange(AgentInformationChangeArgs agentInformationChangeArgs)
        {
            var client = await GenerateHttpClient();
            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(agentInformationChangeArgs), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await client.PostAsync("/apidemo/1.0.0/services/premfin/agent/info/change", httpContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<AgentInformationChange_result>(temp);
                return result;
            }
            else { return null; }
        }

        public async Task<SessionToken> GetSessionToken(LoginArgs loginArgs, HttpClient httpClient)
        {
            //httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string encode = GetBase64Encoding(string.Format($"{loginArgs.key}:{loginArgs.password}"));

            GetSessionArgs getSessionArgs = new GetSessionArgs()
            {
                password = encode,
                userId = loginArgs.userId
            };

            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(getSessionArgs), Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("/apiauth/1.0.0/services/auth/login", httpContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionToken>(temp);
                return result;
            }
            else { return null; }
        }

        private async Task<HttpClient> GenerateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://apidemo.epitomeais.com");

            // get access
            var identity = await GetAccess(client);
            client.DefaultRequestHeaders.Add("Authorization", string.Format($@"Bearer {identity.access_token}"));
            // get session
            LoginArgs loginArgs = new LoginArgs()
            {
                password = "4e52GxZrJeP2@KqG",
                key = "VertExMQU5X6dTda",
                userId = "VERTEXPPFT01"
            };
            var sessionToken = await GetSessionToken(loginArgs, client);

            client.DefaultRequestHeaders.Add("SessionToken", sessionToken.results);
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return await Task.FromResult(client);
        }
    }
}
