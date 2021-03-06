﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateEditGetModel
    {
        public int Id { get; set; }
        public int ProcessTemplateGroupId { get; set; }
        public bool ShowInPersonalCalendar { get; set; }
        public bool ShowInEventCalendar { get; set; }
        public int Lid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }

        
    }

    public class SuProcessTemplateEditGetWithListModel
    {
        public SuProcessTemplateEditGetModel ProcessTemplate { get; set; }
        public List<SelectListItem> GroupList { get; set; }

    }
}
