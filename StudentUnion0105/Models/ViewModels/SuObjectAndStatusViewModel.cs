using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace StudentUnion0105.ViewModels
{
    public class SuObjectAndStatusViewModel
    {
        public SuObjectVM SuObject { get; set; }
        //public List<SuClassificationStatusModel> Status { get; set; }
        public IEnumerable<SelectListItem> SomeKindINumSelectListItem { get; set; }
        public IEnumerable<SelectListItem> ProbablyTypeListItem { get; set; }

        //        public string Description { get; set; }
    }
}
