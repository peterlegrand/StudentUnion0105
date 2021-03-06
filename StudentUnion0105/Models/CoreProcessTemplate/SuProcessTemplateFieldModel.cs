﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFieldModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template id")]
        public int ProcessTemplateId { get; set; }
        public int ProcessTemplateFieldTypeId { get; set; }
      
        [ForeignKey("ProcessTemplateId")]
        public virtual SuProcessTemplateModel ProcessTemplate { get; set; }
        [ForeignKey("ProcessTemplateFieldTypeId")]
        public virtual SuProcessTemplateFieldTypeModel ProcessTemplateFieldType { get; set; }
       
        public virtual ICollection<SuProcessTemplateFieldLanguageModel> ProcessTemplateFieldLanguages { get; set; }
        public virtual ICollection<SuProcessTemplateStepFieldModel> ProcessTemplateFieldSteps { get; set; }


    }
    public class SuProcessTemplateFieldLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template field id")]
        public int ProcessTemplateFieldId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Mouse over")]
        [MaxLength(50)]
        public string MouseOver { get; set; }
        [MaxLength(50)]
        [Display(Name = "Menu name")]
        public string MenuName { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ProcessTemplateFieldId")]
        public virtual SuProcessTemplateFieldModel ProcessTemplateField { get; set; }

        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
