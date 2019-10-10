using StudentUnion0105.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageSectionLanguageModel
    {
        private readonly SuDbContext context;

        public SuClassificationPageSectionLanguageModel(SuDbContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }
        [Display(Name = "Classification page section Id")]
        public int PageSectionId { get; set; }
        public int LanguageId { get; set; }
        [Display(Name = "Page section name")]
        [MaxLength(50)]

        public string ClassificationPageSectionName { get; set; }
        [Display(Name = "Page section description")]
        public string ClassificationPageSectionDescription { get; set; }
        [Display(Name = "Page section title")]
        [MaxLength(50)]

        public string ClassificationPageSectionTitle { get; set; }
        [Display(Name = "Page Section title description")]
        public string ClassificationPageSectionTitleDescription { get; set; }
        [Display(Name = "Page section mouse over")]
        [MaxLength(50)]
        public string ClassificationPageSectionMouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("PageSectionId")]
        public virtual SuClassificationPageSectionModel PageSection { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel PageLanguage { get; set; }


    }
}
