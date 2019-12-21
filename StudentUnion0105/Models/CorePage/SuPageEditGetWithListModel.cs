using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPageEditGetWithListModel
    {
        public SuPageEditGetModel Page { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> TypeList { get; set; }

    }
}
