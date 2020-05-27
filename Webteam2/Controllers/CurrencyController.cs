using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public CurrencyController(Context context)
        {
            _context = context;            
        }

        private static IEnumerable<Currency> currencies =
            JsonConvert.DeserializeObject<IEnumerable<Currency>>
            (System.IO.File.ReadAllText("./Models/X_Change/Data/CurrencyList.json"));

        public async Task<IActionResult> SeedDbWithCurrencies()
        {
            var currenciesToAdd = _context.Currencies;
            await currenciesToAdd.AddRangeAsync(currencies);
            await _context.SaveChangesAsync();
            return new JsonResult("Database has been seeded.");
        }
    }
}
