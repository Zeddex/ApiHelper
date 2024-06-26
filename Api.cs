using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Http;

namespace ApiHelper
{
    public abstract class Api
    {
        const string RegexPattern = @"\{.*\}";
        public string ApiUrl { get; set; }
        public HttpClient HttpClient { get; }

        protected Api(string apiUrl)
        {
            ApiUrl = apiUrl;
            HttpClient = CreateAndConfigureHttpClient();
        }

        protected virtual HttpClient CreateAndConfigureHttpClient()
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            var configureHttpClient = new HttpClient(handler);
            configureHttpClient.BaseAddress = new Uri(ApiUrl);
            configureHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return configureHttpClient;
        }

        protected async Task<string> Call(HttpMethod method, string endpoint, string pathParam = "",  Dictionary<string, object>? requestParams = null, bool bodyAsQueryParams = false)
        {
            string queryParams = "";

            if (!string.IsNullOrEmpty(pathParam))
            {
                endpoint = Regex.Replace(endpoint, RegexPattern, pathParam);
            }

            if (requestParams != null)
            {
                queryParams = Utils.GenerateParamsString(requestParams);
            }

            string requestUri = endpoint;

            HttpRequestMessage? request;
            HttpResponseMessage? response;

            if (method.Method == "POST" || method.Method == "DELETE")
            {
                string jsonBody = "";

                if (!bodyAsQueryParams)
                {
                    jsonBody = Utils.QueryStringToJson(queryParams);
                }

                else
                {
                    requestUri += $"?{queryParams}";
                }

                request = new HttpRequestMessage(method, requestUri)
                {
                    Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
                };

                response = await HttpClient.SendAsync(request);

                return await response.Content.ReadAsStringAsync();
            }

            if (!string.IsNullOrEmpty(queryParams))
            {
                requestUri += $"?{queryParams}";
            }

            request = new HttpRequestMessage(method, requestUri);
            response = await HttpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
