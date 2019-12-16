using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageSectionEditGetWithListModel
    {
        public SuClassificationPageSectionEditGetModel ClassificationPageSection { get; set; }
        public List<SelectListItem> ContentTypeList { get; set; }
        public List<SelectListItem> SectionTypeList { get; set; }
    }
}
