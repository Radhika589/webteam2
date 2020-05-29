using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Webteam2.Models;
using Webteam2.Models.X_Change;

namespace Webteam2.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly Context _context;

        HttpClient client = new HttpClient();
        const string baseUrl = "https://api.exchangeratesapi.io/";

        public CurrencyController(Context context)
        {
            _context = context;
            InitializeCurrencyConverterBaseConnection(client,baseUrl);
        }

        private static IEnumerable<Currency> currencies =
            JsonConvert.DeserializeObject<IEnumerable<Currency>>
            (System.IO.File.ReadAllText("./Models/X_Change/Data/CurrencyList.json"));        
        
        
        public async Task<ICollection<Currency>> GetCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<IActionResult> SeedDbWithCurrencies()
        {
            var currenciesToAdd = _context.Currencies;
            await currenciesToAdd.AddRangeAsync(currencies);
            await _context.SaveChangesAsync();
            return new JsonResult("Database has been seeded.");
        }

        /// <summary>
        /// Establishes the base connection to the currency convertor API.
        /// </summary>
        /// <param name="client">The base Http Client.</param>
        /// <param name="url">The base url to the API.</param>
        /// <returns></returns>
        static void InitializeCurrencyConverterBaseConnection(
            HttpClient client, string url)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.
                Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Aquires the x-change rates of major currencies against a given base currency.
        /// </summary>
        /// <param name="client">The base Http Client. Must be initialized with InitializeCurrencyConverterBaseConnection first.</param>
        /// <param name="baseCurrency">The currency against which the x-change rates of other major currencies will be quoted.</param>
        /// <returns></returns>
        private static async Task<CurrencyConverterApiResponse> GetRates(HttpClient client, string baseCurrency)
        {
            CurrencyConverterApiResponse currencyResponse = null;
            HttpResponseMessage response =
                await client.GetAsync($"latest?base={baseCurrency}");
            if (response.IsSuccessStatusCode)
                currencyResponse =
                    await response.Content.ReadAsAsync<CurrencyConverterApiResponse>();
            return currencyResponse;
        }

        public async Task<JsonResult> CalculateLocalCurrency(string currencyAbbreviation, int amount) 
        {
            var _amount = amount;
            var _currencyAbbreviation = currencyAbbreviation;

            var todaysRates =await GetRates(client,"SEK");
            double targetRate = -1;
            var currencyExists=todaysRates.Rates.TryGetValue(currencyAbbreviation, out targetRate);
            if (currencyExists)
            {
                var amountInLocalCurrency = Math.Round(amount * targetRate, 2);
                return Json(amountInLocalCurrency);
            }
            else if(currencyAbbreviation=="Please Choose A Currency")
            {
                return Json("You have not chosen a valid currency!");
            }
            return Json("Either this currency does not exist in the database," +
                "or some unknown error has occurred.");
        }
    }
}
