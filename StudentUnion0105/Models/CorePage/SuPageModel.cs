using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPageModel
    {
        public int Id { get; set; }
        [Display(Name = "Page status id")]
        public int PageStatusId { get; set; }
        [Display(Name = "Page type id")]
        public int PageTypeId { get; set; }
        public bool ShowTitleName { get; set; }
        public bool ShowTitleDescription { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("PageStatusId")]
        public virtual SuPageStatusModel PageStatus { get; set; }
        [ForeignKey("PageTypeId")]
        public virtual SuPageTypeModel PageType { get; set; }
        public virtual ICollection<SuPageLanguageModel> PageLanguages { get; set; }
        public virtual ICollection<SuPageSectionModel> PageSections { get; set; }

    }
    public class SuPageLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Page id")]
        public int PageId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Mouse over")]
        [MaxLength(50)]
        public string MouseOver { get; set; }
        [MaxLength(50)]
        [Display(Name = "Menu name")]
        public string MenuName { get; set; }
        [Display(Name = "Page title")]
        [MaxLength(50)]
        public string TitleName { get; set; }
        [Display(Name = "Page description")]
        public string TitleDescription { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("PageId")]
        public virtual SuPageModel Page { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }
}
