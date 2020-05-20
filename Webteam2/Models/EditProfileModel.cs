using System.ComponentModel.DataAnnotations;

namespace Webteam2.Models
{
    public class EditProfileModel
    {
        [Required(ErrorMessage = "You cannot enter an empty description, write something about yourself!")]
        [StringLength(200, ErrorMessage = "Your description cannot be longer than 200 chars.")]
        public string Description { get; set; }
        public Profile UserProfile { get; set; }
    }
}