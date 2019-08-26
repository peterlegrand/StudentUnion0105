using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.ViewModels
{
    public class SuObjectAndStatusViewModel
    {
        public SuObjectVM SuObject {get;set;}
        //public List<SuClassificationStatusModel> Status { get; set; }
        public IEnumerable<SelectListItem> SomeKindINumSelectListItem { get; set; }
    }
}
