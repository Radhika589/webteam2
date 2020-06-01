using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webteam2.Models.X_Change
{
    public class CurrencyConvertionClientResponse
    {
        [JsonProperty("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("localCurrency")]
        public string LocalCurrency { get; set; }

        [JsonProperty("baseToLocalCurrencyRate")]
        public double BaseToLocalCurrencyRate { get; set; }

        [JsonProperty("calculatedAmount")]
        public double CalculatedAmount { get; set; }
    }
}
