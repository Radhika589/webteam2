using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webteam2
{
    public class Profile
    {
        public string Id { get; set; }
        public string PictureURL { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public virtual User User { get; set; }
    }
}
