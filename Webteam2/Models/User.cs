using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webteam2.Models
{
    public class User
    {
        [Key]
        public virtual string Id { get; set; }
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        [Required]
        public virtual string Tel { get; set; }
        [Required]
        public virtual string Location { get; set; }
        public virtual int Reputation { get; set; }
    }
}
