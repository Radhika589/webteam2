using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webteam2.Models
{
    public class User
    {
        [Column("id")]
        public virtual string Id { get; set; }
    }
}
