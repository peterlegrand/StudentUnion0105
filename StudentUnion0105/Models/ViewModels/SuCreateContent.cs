using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.ViewModels
{
    public class SuCreateContentModel
    {
        public SuContentModel Content { get; set; }
        public IEnumerable<SelectListItem> ContentType { get; set; }
        public IEnumerable<SelectListItem> ContentStatus { get; set; }
        public IEnumerable<SelectListItem> Organization { get; set; }
        public IEnumerable<SelectListItem> Project { get; set; }
        public IEnumerable<SelectListItem> SecurityLevel { get; set; }
        public IEnumerable<SelectListItem> Langauge { get; set; }
        public IEnumerable<SelectListItem>[] Values { get; set; }
        public int?[] SelectedValues { get; set; }
        public int? NoOfClassifications { get; set; }
    }
}
