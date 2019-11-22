using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationValueEditGetLevelModel
    {
        [Key]
        public int DateLevel { get; set; }
        public bool InDropDown { get; set; }
    }
}
