using System.Collections.Generic;

namespace Webteam2.Models
{
    public class ProfileViewModel
    {
        public Profile UserProfile { get; set; }

        public IEnumerable<Issue> UserIssues { get; set; }
        
        public bool IsContractor { get; set; }
        
    }
}