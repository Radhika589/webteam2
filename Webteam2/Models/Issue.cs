using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webteam2.Models
{
    public class Issue
    {
        //[Key]
        public virtual string Id { get; set; }
        //[Required]
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        //[Required]
        public virtual string Location { get; set; }
        //[Required]
        public virtual int Payment { get; set; }
        //[Required]
        public virtual User Issuer { get; set; }
    }
}
