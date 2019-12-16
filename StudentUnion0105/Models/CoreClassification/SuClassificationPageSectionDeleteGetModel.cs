﻿using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageSectionDeleteGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int Sequence { get; set; }
        public string SectionTypeName { get; set; }
        public bool ShowSectionTitleName { get; set; }
        public bool ShowSectionTitleDescription { get; set; }
        public bool ShowContentTypeTitleName { get; set; }
        public bool ShowContentTypeTitleDescription { get; set; }
        public int OneTwoColumns { get; set; }
        public string ContentTypeName { get; set; }
        public int SortById { get; set; }
        public int MaxContent { get; set; }
        public bool HasPaging { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
