using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.ViewModels
{
    public class SuProcessTemplateFieldWith2DropDown
    {
        public SuObjectVM Field { get; set; }
        public IEnumerable<SelectListItem> MasterList { get; set; }
        public IEnumerable<SelectListItem> DataTypes { get; set; }
    }
}
