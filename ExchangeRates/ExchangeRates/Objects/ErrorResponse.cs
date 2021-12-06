using System.Text.Json.Serialization;

namespace ExchangeRates.Objects
{
    public class ErrorResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("documentation")]
        public string Documentation { get; set; }

        [JsonPropertyName("terms-of-use")]
        public string TermsOfUse { get; set; }

        [JsonPropertyName("error-type")]
        public string ErrorType { get; set; }
    }
}