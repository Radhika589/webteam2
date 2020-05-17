using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webteam2.Models.Geo;

namespace Webteam2.Models
{
    public class Issue
    {
        [Key]
        public virtual string Id { get; set; }

        [Required(ErrorMessage = "Title is required"), MaxLength(50, ErrorMessage = "Max 50 characters."), MinLength(5, ErrorMessage = "Too short.")]
        public virtual string Title { get; set; }
        [Required(ErrorMessage = "Description is required"), MaxLength(500, ErrorMessage = "Max 500 characters."), MinLength(10, ErrorMessage = "Too short.")]
        public virtual string Description { get; set; }
        //[Required(ErrorMessage = "You need to enter a location."), MinLength(2, ErrorMessage = "Too short."), MaxLength(30, ErrorMessage = "Max 30 characters")]
        //public virtual string Location { get; set; }
        [Required(ErrorMessage = "A price is required"), Range(0,999999, ErrorMessage = "Min 0 Max 999 999")]
        public virtual int Payment { get; set; }
        //[Required]
        public virtual User Issuer { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required(ErrorMessage = "Please select a location.")]
        public virtual int CityId { get; set; }
    }
}
