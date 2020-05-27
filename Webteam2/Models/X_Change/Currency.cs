using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Webteam2.Models.X_Change
{
    public class Currency
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string FullName { get; set; }
    }
}
