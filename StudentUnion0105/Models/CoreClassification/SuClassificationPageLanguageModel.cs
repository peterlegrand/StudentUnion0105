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
