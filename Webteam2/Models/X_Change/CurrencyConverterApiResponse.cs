using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Webteam2.Models.X_Change
{
    public class CurrencyConverterApiResponse
    {
        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
    }
}
