using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ApiHelper
{
    /// <summary>
    /// https://api.ston.fi/
    /// </summary>
    /// <param name="apiUrl"></param>
    public class StonApi(string apiUrl) : Api(apiUrl)
    {
        public async Task<string> GetAssets()
        {
            return await Call(HttpMethod.Get, StonEndpoints.Dex.Assets);
        }

        public async Task<string> GetAssetByAddress(string address)
        {
            return await Call(HttpMethod.Get, StonEndpoints.Dex.AssetByAddress, address);
        }

        public async Task<string> GetMarkets()
        {
            return await Call(HttpMethod.Get, StonEndpoints.Dex.Markets);
        }

        public async Task<string> GetPools()
        {
            return await Call(HttpMethod.Get, StonEndpoints.Dex.Pools);
        }

        public async Task<string> GetPoolByAddress(string address)
        {
            return await Call(HttpMethod.Get, StonEndpoints.Dex.PoolByAddress, address);
        }

        public async Task<string> GetSwapStatus(string routerAddress, string ownerAddress, string queryId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "router_address", routerAddress },
                { "owner_address", ownerAddress },
                { "query_id", queryId }
            };

            return await Call(HttpMethod.Get, StonEndpoints.Dex.SwapStatus, "", parameters);
        }

        public async Task<string> SwapSimulate(string offerAddress, string askAddress, string units, string slippageTolerance)
        {
            var parameters = new Dictionary<string, object>
            {
                { "offer_address", offerAddress },
                { "ask_address", askAddress },
                { "units", units },
                { "slippage_tolerance", slippageTolerance }
            };

            return await Call(HttpMethod.Post, StonEndpoints.Dex.SwapSimulate, "", parameters, true);
        }

        public async Task<string> ReverseSwapSimulate(string offerAddress, string askAddress, string units, string slippageTolerance)
        {
            var parameters = new Dictionary<string, object>
            {
                { "offer_address", offerAddress },
                { "ask_address", askAddress },
                { "units", units },
                { "slippage_tolerance", slippageTolerance }
            };

            return await Call(HttpMethod.Post, StonEndpoints.Dex.ReverseSwapSimulate, "", parameters, true);
        }

        public async Task<string> GetJettonByAddress(string ownerAddress, string address)
        {
            var parameters = new Dictionary<string, object>
            {
                { "owner_address", ownerAddress }
            };

            return await Call(HttpMethod.Get, StonEndpoints.Jetton.JettonByAddress, address, parameters);
        }

        public async Task<string> GetWalletAssets(string address)
        {
            return await Call(HttpMethod.Get, StonEndpoints.Wallets.Assets, address);
        }

        public async Task<string> GetFarms(string address)
        {
            return await Call(HttpMethod.Get, StonEndpoints.Wallets.Farms, address);
        }

        public async Task<string> GetPools(string address)
        {
            return await Call(HttpMethod.Get, StonEndpoints.Wallets.Pools, address);
        }
    }
}
