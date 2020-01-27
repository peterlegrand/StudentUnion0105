using StudentUnion0105.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageModel
    {
        private readonly SuDbContext context;

        public SuClassificationPageModel(SuDbContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }
        [Display(Name = "Classification id")]
        public int ClassificationId { get; set; }
        [Display(Name = "Classification page status id")]
        public int StatusId { get; set; }
        [Display(Name = "Show classification title")]
        public bool ShowTitleName { get; set; }
        [Display(Name = "Show classification title description")]
        public bool ShowTitleDescription { get; set; }
        [Display(Name = "Show classification page title")]
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationId")]
        public virtual SuClassificationModel Classification { get; set; }
        public virtual ICollection<SuClassificationPageLanguageModel> PageLanguages { get; set; }

    }

    public class SuClassificationPageLanguageModel
    {


        public int Id { get; set; }
        [Display(Name = "Classification page id")]
        public int ClassificationPageId { get; set; }
        public int LanguageId { get; set; }
        [Display(Name = "Page name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Page description")]
        public string Description { get; set; }
        [Display(Name = "Menu name")]
        [MaxLength(50)]
        public string MenuName { get; set; }
        [Display(Name = "Page mouse over")]
        [MaxLength(50)]
        public string MouseOver { get; set; }
        [Display(Name = "Page title")]
        [MaxLength(50)]
        public string TitleName { get; set; }
        [Display(Name = "Page description")]
        public string TitleDescription { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationPageId")]
        public virtual SuClassificationPageModel ClassificationPage { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }


    }

}
