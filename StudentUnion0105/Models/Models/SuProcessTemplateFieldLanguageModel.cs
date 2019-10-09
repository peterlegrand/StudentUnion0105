﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFieldLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template field id")]
        public int ProcessTemplateFieldId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string ProcessTemplateFieldName { get; set; }
        [Display(Name = "Description")]
        public string ProcessTemplateFieldDescription { get; set; }
        [Display(Name = "Mouse over")]
        [MaxLength(50)]
        public string ProcessTemplateFieldMouseOver { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ProcessTemplateFieldId")]
        public virtual SuProcessTemplateFieldModel ProcessTemplateField { get; set; }

        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
