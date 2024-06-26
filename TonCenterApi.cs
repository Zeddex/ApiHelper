using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ApiHelper
{
    /// <summary>
    /// https://toncenter.com/api/v2/
    /// https://toncenter.com/api/v3/
    /// </summary>
    public class TonCenterApi(string apiUrl, string apiKey = "") : Api(apiUrl)
    {
        public string ApiKey { get; set; } = apiKey;

        protected override HttpClient CreateAndConfigureHttpClient()
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            var configureHttpClient = new HttpClient(handler);
            configureHttpClient.BaseAddress = new Uri(ApiUrl);
            configureHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(ApiKey))
            {
                configureHttpClient.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            }

            return configureHttpClient;
        }

        public async Task<string> EstimateFee(string address, string body, string initCode, string initData)
        {
            var parameters = new Dictionary<string, object>
            {
                { "address", address },
                { "body", body },
                { "init_code", initCode },
                { "init_data", initData }
            };

            return await Call(HttpMethod.Post, TonCenterEndpoints.V2.Send.EstimateFee, "", parameters);
        }
    }
}

