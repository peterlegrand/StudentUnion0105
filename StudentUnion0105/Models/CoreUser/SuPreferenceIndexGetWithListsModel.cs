using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPreferenceIndexGetWithListsModel
    {
        
        public SuPreferenceIndexGetModel Preference { get; set; }
        public List<SelectListItem> Languages { get; set; }
        public List<SelectListItem> Countries { get; set; }
    }
}
