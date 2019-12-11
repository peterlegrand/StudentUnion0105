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
        public string Name { get; set; }
        [Display(Name = "Page section description")]
        public string Description { get; set; }
        [Display(Name = "Page section menu name")]
        [MaxLength(50)]
        public string MenuName { get; set; }
        [Display(Name = "Page section Mouse over")]
        [MaxLength(50)]
        public string MouseOver { get; set; }
        [Display(Name = "Page section title")]
        [MaxLength(50)]

        public string Title { get; set; }
        [Display(Name = "Page Section title description")]
        public string TitleDescription { get; set; }
        [Display(Name = "Page section mouse over")]
        [MaxLength(50)]
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("PageSectionId")]
        public virtual SuClassificationPageSectionModel PageSection { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel PageLanguage { get; set; }


    }
}
