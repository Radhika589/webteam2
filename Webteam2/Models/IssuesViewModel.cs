using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webteam2.Models
{
    public class IssuesViewModel
    {
        public List<Issue> UserIssues { get; set; }
        public List<Issue> AllIssues { get; set; }
    }
}
