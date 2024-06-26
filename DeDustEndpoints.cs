namespace ApiHelper
{
    /// <summary>
    /// https://api.dedust.io/
    /// </summary>
    public class DeDustEndpoints
    {
        public static class Dex
        {
            public const string RoutingPlan = "/v2/routing/plan";
        }

        public static class Account
        {
            public const string Assets = "/v2/accounts/{address}/assets";
            public const string Trades = "/v2/accounts/{address}/trades";
        }

        public static class Asset
        {
            public const string Available = "/v2/assets";
            public const string BySymbol = "/v2/assets/{symbol}";
        }

        public static class Price
        {
            public const string Prices = "/v2/prices";
        }

        public static class Pool
        {
            public const string Pools = "/v2/pools";
            public const string PoolsLite = "/v2/pools-lite";
            public const string Metadata = "/v2/pools/{address}/metadata";
            public const string Trades = "/v2/pools/{address}/trades";
        }

        public static class CoinGecko
        {
            public const string PairsAvailable = "/v2/gcko/pairs";
            public const string Tickers = "/v2/gcko/tickers";
            public const string Trades = "/v2/gcko/trades";
        }

        public static class Jetton
        {
            public const string Supply = "/v2/jettons/{address}/circulating-supply";
            public const string Metadata = "/v2/jettons/{address}/metadata";
            public const string TopBuys = "/v2/jettons/{address}/top-buys";
            public const string TopTraders = "/v2/jettons/{address}/top-traders";
            public const string TotalSupply = "/v2/jettons/{address}/total-supply";
        }
    }
}
