using System.ComponentModel.DataAnnotations;

namespace Webteam2.Models
{
    public class EditProfileModel
    {
        [Required(ErrorMessage = "Write something about yourself!")]
        public string Description { get; set; }
        public Profile UserProfile { get; set; }
    }
}