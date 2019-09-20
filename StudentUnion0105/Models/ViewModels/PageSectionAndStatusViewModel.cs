﻿using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.ViewModels
{
    public class PageSectionAndStatusViewModel
    {
        public SuObjectVMPageSection SuObject {get;set;}
        //public List<SuClassificationStatusModel> Status { get; set; }
        public IEnumerable<SelectListItem> SomeKindINumSelectListItem { get; set; }
        public IEnumerable<SelectListItem> ProbablyTypeListItem { get; set; }
        public IEnumerable<SelectListItem> ProbablyTypeListItem2 { get; set; }

        //        public string Description { get; set; }
    }
}
