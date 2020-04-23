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
        public virtual int ID { get; set; }
        public virtual string OwnerID { get; set; }

        [Required]
        public virtual string Title { get; set; }
        [Required]
        public virtual string Description { get; set; }
        [Required]
        public virtual string Location { get; set; }
        [Required]
        public virtual int Payment { get; set; }

        public virtual IEnumerable<User> Contractors { get; set; }
    }
}
