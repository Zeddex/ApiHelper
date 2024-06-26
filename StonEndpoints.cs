namespace ApiHelper
{
    /// <summary>
    /// https://api.ston.fi/
    /// </summary>
    public class StonEndpoints
    {
        public static class Dex
        {
            public const string Assets = "/v1/assets";
            public const string AssetByAddress = "/v1/assets/{addr_str}";
            public const string Farms = "/v1/farms";
            public const string FarmByAddress = "/v1/farms/{addr_str}";
            public const string FarmByPools = "/v1/farms_by_pool/{pool_addr_str}";
            public const string Markets = "/v1/markets";
            public const string Pools = "/v1/pools";
            public const string PoolByAddress = "/v1/pools/{addr_str}";
            public const string ReverseSwapSimulate = "/v1/reverse_swap/simulate";
            public const string SwapSimulate = "/v1/swap/simulate";
            public const string SwapStatus = "/v1/swap/status";
        }

        public static class Jetton
        {
            public const string JettonByAddress = "/v1/jetton/{addr_str}/address";
        }

        public static class Wallets
        {
            public const string Assets = "/v1/wallets/{addr_str}/assets";
            public const string Farms = "/v1/wallets/{addr_str}/farms";
            public const string Operations = "/v1/wallets/{addr_str}/operations";
            public const string Pools = "/v1/wallets/{addr_str}/pools";
        }

        public static class Stats
        {
            public const string Dex = "/v1/stats/dex";
            public const string Operations = "/v1/stats/operations";
            public const string Pool = "/v1/stats/pool";
        }
    }
}
