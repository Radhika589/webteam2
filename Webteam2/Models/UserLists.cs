using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webteam2.Models
{
    public class UserLists
    {
        public IList<User> Customers { get; set; }
        public IList<User> NotValidatedContractors { get; set; }
        public IList<User> ValidatedContractors { get; set; }
        public IList<User> Administrators { get; set; }
    }
}
