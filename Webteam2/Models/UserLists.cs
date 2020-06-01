using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Webteam2.Models
{
    public class UserLists

    {
    public IList<User> Customers { get; set; }
    public IList<User> NotValidatedContractors { get; set; }
    public IList<User> ValidatedContractors { get; set; }
    public IList<User> Administrators { get; set; }
    [BindProperty(SupportsGet = true)] public string SearchString { get; set; }
    public SelectList AllCities { get; set; }
    [BindProperty(SupportsGet = true)] public string SelectedCity { get; set; }
    }
}
