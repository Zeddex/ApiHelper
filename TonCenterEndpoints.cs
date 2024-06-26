namespace ApiHelper
{
    /// <summary>
    /// https://toncenter.com/api/v2/
    /// https://toncenter.com/api/v3/
    /// </summary>
    public class TonCenterEndpoints
    {
        public static class V2
        {
            public static class Account
            {
                public const string GetAddressInfo = "/api/v2/getAddressInformation";
                public const string GetExtAddressInfo = "/api/v2/getExtendedAddressInformation";
                public const string GetWalletInfo = "/api/v2/getWalletInformation";
                public const string GetTransactions = "/api/v2/getTransactions";
                public const string GetAddressBalance = "/api/v2/getAddressBalance";
                public const string GetAddressState = "/api/v2/getAddressBalance";
                public const string PackAddress = "/api/v2/packAddress";
                public const string UnpackAddress = "/api/v2/unpackAddress";
                public const string GetTokenData = "/api/v2/getTokenData";
                public const string DetectAddress = "/api/v2/detectAddress";
            }

            public static class Block
            {
                public const string GetMasterchainInfo = "/api/v2/getMasterchainInfo";
                public const string GetBlockTransactions = "/api/v2/getBlockTransactions";
                public const string GetExtBlockTransactions = "/api/v2/getBlockTransactionsExt";
            }

            public static class Send
            {
                public const string SendBoc = "/api/v2/sendBoc";
                public const string SendBocReturnHash = "/api/v2/sendBocReturnHash";
                public const string SendQuery = "/api/v2/sendQuery";
                public const string EstimateFee = "/api/v2/estimateFee";
            }

            public static class Transaction
            {
                public const string GetTransactions = "/api/v2/getTransactions";
                public const string GetBlockTransactions = "/api/v2/getBlockTransactions";
                public const string GetExtBlockTransactions = "/api/v2/getBlockTransactionsExt";
                public const string TryLocateTx = "/api/v2/tryLocateTx";
                public const string TryLocateResultTx = "/api/v2/tryLocateResultTx";
                public const string TryLocateSourceTx = "/api/v2/tryLocateSourceTx";
            }
        }

        public static class V3
        {
            public const string AccountInfo = "/api/v3/account";
            public const string WalletInfo = "/api/v3/wallet";
            public const string EstimateFee = "/api/v3/estimateFee";
            public const string SendMessage = "/api/v3/message";
            public const string RunGetMethod = "/api/v3/runGetMethod";
            public const string GetJettonTransfers = "/api/v3/runGetMethod";
            public const string GetJettonWallets = "/api/v3/jetton/wallets";
            public const string GetMessages = "/api/v3/messages";
            public const string GetTransactionByMsg = "/api/v3/transactionsByMessage";
            public const string GetTransactions = "/api/v3/transactions";
            public const string GetAddressBook = "/api/v3/addressBook";
            public const string GetBlocks = "/api/v3/blocks";
            public const string GetMasterchainInfo = "/api/v3/masterchainInfo";
        }
    }
}
