﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuUserOrganizationTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SuUserOrganizationModel> UserOrganizations { get; set; }
        public virtual ICollection<SuUserOrganizationTypeLanguageModel> UserOrganizationTypLanguages { get; set; }

    }
    public class SuUserOrganizationTypeLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Type id")]
        public int TypeId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(50)]
        [Display(Name = "Menu name")]
        public string MenuName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Mouse over")]
        public string MouseOver { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("TypeId")]
        public virtual SuUserOrganizationTypeModel Type { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
