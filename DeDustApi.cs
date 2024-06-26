using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace ApiHelper
{
    /// <summary>
    /// https://api.dedust.io/
    /// </summary>
    /// <param name="apiUrl"></param>
    public class DeDustApi(string apiUrl) : Api(apiUrl)
    {
        public async Task<string> GetPoolsLite()
        {
            return await Call(HttpMethod.Get, DeDustEndpoints.Pool.PoolsLite);
        }

        public async Task<string> GetAssets()
        {
            return await Call(HttpMethod.Get, DeDustEndpoints.Asset.Available);
        }

        public async Task<string> GetJettonData(string address)
        {
            return await Call(HttpMethod.Get, DeDustEndpoints.Jetton.Metadata, address);
        }
    }
}
