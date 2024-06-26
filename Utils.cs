using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper
{
    public static class Utils
    {
        public static string GenerateParamsString(Dictionary<string, object> parameters, bool isSorted = false)
        {
            IDictionary<string, object> paramList;

            if (isSorted)
            {
                paramList = new SortedDictionary<string, object>(parameters);
            }

            else
            {
                paramList = new Dictionary<string, object>(parameters);
            }

            var stringBuffer = new StringBuilder();

            foreach (var entry in paramList)
            {
                stringBuffer.Append(entry.Key).Append("=").Append(entry.Value).Append("&");
            }

            string paramsString = stringBuffer.ToString().Substring(0, stringBuffer.Length - 1);

            return paramsString;
        }

        public static string QueryStringToJson(string query)
        {
            var dictionary = query.Replace("?", "").Split('&')
                .ToDictionary(x => x.Split('=')[0], x => x.Split('=')[1]);

            var json = JsonConvert.SerializeObject(dictionary);

            return json;
        }

        public static string JsonToQueryString(string jsonString)
        {
            var jsonObject = JObject.Parse(jsonString);

            var queryStringParameters = new Dictionary<string, string>();

            FlattenJson(jsonObject, queryStringParameters, null);

            var queryString = string.Join("&", queryStringParameters.Select(kvp =>
                $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value)}"));

            return queryString;
        }

        private static void FlattenJson(JObject jsonObject, Dictionary<string, string> queryStringParameters, string parentKey)
        {
            foreach (var property in jsonObject.Properties())
            {
                var key = string.IsNullOrEmpty(parentKey) ? property.Name : $"{parentKey}.{property.Name}";
                var value = property.Value;

                if (value is JObject nestedObject)
                {
                    FlattenJson(nestedObject, queryStringParameters, key);
                }
                else if (value is JArray array)
                {
                    for (int i = 0; i < array.Count; i++)
                    {
                        var arrayItem = array[i];
                        if (arrayItem is JObject)
                        {
                            FlattenJson((JObject)arrayItem, queryStringParameters, $"{key}[{i}]");
                        }
                        else
                        {
                            queryStringParameters[$"{key}[{i}]"] = arrayItem.ToString();
                        }
                    }
                }
                else
                {
                    queryStringParameters[key] = value.ToString();
                }
            }
        }
    }
}
