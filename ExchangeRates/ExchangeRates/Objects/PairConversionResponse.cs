﻿using System.Text.Json.Serialization;

namespace ExchangeRates.Objects
{
    public class PairConversionResponse
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
        public string TimeLastUpdateUtc { get; set; }

        [JsonPropertyName("time_next_update_unix")]
        public int TimeNextUpdateUnix { get; set; }

        [JsonPropertyName("time_next_update_utc")]
        public string TimeNextUpdateUtc { get; set; }

        [JsonPropertyName("base_code")]
        public string BaseCode { get; set; }

        [JsonPropertyName("target_code")]
        public string TargetCode { get; set; }

        [JsonPropertyName("conversion_rate")]
        public double ConversionRate { get; set; }

        [JsonPropertyName("conversion_result")]
        public double? ConversionResult { get; set; }
    }
}