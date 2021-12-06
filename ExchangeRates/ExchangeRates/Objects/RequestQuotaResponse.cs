using System.Text.Json.Serialization;

namespace ExchangeRates.Objects
{
    public class RequestQuotaResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("documentation")]
        public string Documentation { get; set; }

        [JsonPropertyName("terms_of_use")]
        public string TermsOfUse { get; set; }

        [JsonPropertyName("plan_quota")]
        public int PlanQuota { get; set; }

        [JsonPropertyName("requests_remaining")]
        public int RequestsRemaining { get; set; }

        [JsonPropertyName("refresh_day_of_month")]
        public int RefreshDayOfMonth { get; set; }
    }
}