using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webteam2.Models
{
    public class Issue
    {
        public virtual int ID { get; set; }
        public virtual string OwnerID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
    }
}
