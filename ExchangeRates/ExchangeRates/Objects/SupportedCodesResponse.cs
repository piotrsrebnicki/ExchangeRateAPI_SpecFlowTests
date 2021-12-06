using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ExchangeRates.Objects
{
    public class SupportedCodesResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("documentation")]
        public string Documentation { get; set; }

        [JsonPropertyName("terms_of_use")]
        public string TermsOfUse { get; set; }

        [JsonPropertyName("supported_codes")]
        public List<List<string>> SupportedCodes { get; set; }
    }
}