using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webteam2.Models;
using Webteam2.Models.Geo;

namespace Webteam2.Controllers
{
    public class LocationsController : ControllerBase
    {
        private readonly Context _context;

        public LocationsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Region>>> GetAllRegions()
        {
            return await _context.Region.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCities()
        {
            return await _context.City.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities(int region)
        {
            return await _context.City.Include(m => m.Region).Where(m => m.Region.Id == region).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<City>> GetCity(int? id)
        {
            if (id.HasValue && DoExist<City>(id))
            {
                return await _context.City.FindAsync(id);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<JsonResult> GetLocation(int? id)
        {
            if (id.HasValue && DoExist<City>(id))
            {
                var city = await _context.City.FindAsync(id);
                var locations = new double[] { city.Longitude, city.Latitude };
                return new JsonResult(locations);
            }
            return new JsonResult("error");
        }

        /// <summary>
        /// Checks if db has any data based on T, if no id is provided it checks if database exist.
        /// </summary>
        /// <typeparam name="T">City or Region</typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DoExist<T>(int? id = null) where T : class
        {                        //true                                //false
            return id.HasValue ? _context.Set<T>().Find(id) != null : _context.Set<T>().Any();
        }

        [HttpGet]
        public async Task<IActionResult> SetupGeoData()
        {
            var cities = _context.City;
            var regions = _context.Region;
            var _regions = GeoDataJson.Regions();
            if (!await regions.AnyAsync())
            {
                try
                {
                    await cities.AddRangeAsync(GeoDataJson.Cities());
                }
                catch (Exception e)
                {
                    return new JsonResult(e);
                }
                await _context.SaveChangesAsync();
                return new JsonResult("Success!");
            }
            return new JsonResult("Nothing to do here...");
        }

        private struct GeoDataJson
        {
            private struct JRegion
            {
                public int id { get; set; }
                public string name { get; set; }

                public IEnumerable<City> Cities { get; set; }

                public Models.Geo.Region ToRegion()
                {
                    return new Models.Geo.Region { Name = name, Id = id };
                }
            }

            private static IEnumerable<JRegion> Data => JsonConvert.DeserializeObject<IEnumerable<JRegion>>(System.IO.File.ReadAllText("./Models/Geo/Data/geodata.json"));

            public static IEnumerable<Models.Geo.Region> Regions()
            {
                var regs = new List<Models.Geo.Region>();
                foreach (var region in Data)
                {
                    regs.Add(region.ToRegion());
                }
                return regs;
            }

            public static IEnumerable<Models.Geo.City> Cities()
            {
                var cities = new List<Models.Geo.City>();
                var regions = Data;
                foreach (var region in Data)
                {
                    var _region = region.ToRegion();
                    foreach (var city in region.Cities)
                    {
                        city.Region = _region;
                    }
                    cities.AddRange(region.Cities);
                }
                return cities;
            }
        }
    }
}