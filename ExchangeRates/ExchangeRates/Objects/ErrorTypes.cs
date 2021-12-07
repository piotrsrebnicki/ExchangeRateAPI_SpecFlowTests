using System.Collections.Generic;

namespace ExchangeRates.Objects
{
    public class ErrorTypes
    {
        public const string UnsupportedCode = "unsupported-code";
        public const string MalformedRequest = "malformed-request";
        public const string InvalidKey = "invalid-key";
        public const string InactiveAccount = "inactive-account";
        public const string QuotaReached = "quota-reached";

        public static readonly List<string>  errorTypes = new List<string>()
            {
                UnsupportedCode,
                MalformedRequest,
                InvalidKey,
                InactiveAccount,
                QuotaReached
            };
    }
}