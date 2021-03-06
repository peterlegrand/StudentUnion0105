﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageSectionTypeModel
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuClassificationPageSectionModel> ClassificationPageSections { get; set; }
        public virtual ICollection<SuClassificationPageSectionTypeLanguageModel> ClassificationPageSectionTypeLanguages { get; set; }

    }
    public class SuClassificationPageSectionTypeLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Page section type Id")]
        public int ClassificationPageSectionTypeId { get; set; }
        [Display(Name = "Page section type language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Page section mouse name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Page section type description")]
        public string Description { get; set; }
        [Display(Name = "Page section type menu name")]
        [MaxLength(50)]
        public string MenuName { get; set; }
        [Display(Name = "Page section type mouse over")]
        [MaxLength(50)]
        public string MouseOver { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationPageSectionTypeId")]
        public virtual SuClassificationPageSectionTypeModel PageType { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }

}
