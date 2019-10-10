using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.IdentityViewModels;
using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.ViewModels
{
    public class SuUserAndLists
    {
        public CreateUserViewModel  User { get; set; }
        public IEnumerable<SelectListItem> Languages { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        //        public string Description { get; set; }
    }
}
