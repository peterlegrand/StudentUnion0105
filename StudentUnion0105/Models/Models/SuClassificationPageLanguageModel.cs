using StudentUnion0105.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageLanguageModel
    {
        private readonly SuDbContext context;

        public SuClassificationPageLanguageModel(SuDbContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }
        [Display(Name = "Classification page id")]
        public int ClassificationPageId { get; set; }
        public int LanguageId { get; set; }
        [Display(Name = "Page name")]
        [MaxLength(50)]
        public string ClassificationPageName { get; set; }
        [Display(Name = "Page description")]
        public string ClassificationPageDescription { get; set; }
        [Display(Name = "Page mouse over")]
        [MaxLength(50)]
        public string ClassificationPageMouseOver { get; set; }
        [Display(Name = "Page title")]
        [MaxLength(50)]
        public string ClassificationPageTitle { get; set; }
        [Display(Name = "Page description")]
        public string ClassificationPageTitleDescription { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationPageId")]
        public virtual SuClassificationPageModel ClassificationPage { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }


    }
}
