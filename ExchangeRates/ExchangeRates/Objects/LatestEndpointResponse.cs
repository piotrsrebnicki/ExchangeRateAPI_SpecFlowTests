using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ExchangeRates.Objects
{
    public class LatestEndpointResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("documentation")]
        public string Documentation { get; set; }

        [JsonPropertyName("terms_of_use")]
        public string TermsOfUse { get; set; }

        [JsonPropertyName("time_last_update_unix")]
        public int TimeLastUpdateUnix { get; set; }

        [JsonPropertyName("time_last_update_utc")]
        public DateTime TimeLastUpdateUtc { get; set; }

        [JsonPropertyName("time_next_update_unix")]
        public int TimeNextUpdateUnix { get; set; }

        [JsonPropertyName("time_next_update_utc")]
        public DateTime TimeNextUpdateUtc { get; set; }

        [JsonPropertyName("base_code")]
        public string BaseCode { get; set; }

        [JsonPropertyName("conversion_rates")]
        public Dictionary<string, float> ConversionRates { get; set; }
    }
}
