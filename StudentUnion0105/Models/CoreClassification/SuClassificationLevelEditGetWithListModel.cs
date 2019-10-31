using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationLevelEditGetWithListModel
    {
        public SuClassificationLevelEditGetModel ClassificationLevel { get; set; }
        public List<SelectListItem> SequenceList { get; set; }
        public List<SelectListItem> DateTypeList { get; set; }

    }
}
