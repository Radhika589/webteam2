using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webteam2.Models.Geo
{
    public class City
    {
        public virtual int id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }

        public virtual Region Region { get; set; }

        public double[] Coordinates => new[] {Longitude, Latitude};
    }
}
