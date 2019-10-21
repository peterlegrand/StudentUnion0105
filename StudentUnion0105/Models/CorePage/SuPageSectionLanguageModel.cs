using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPageSectionLanguageModel
    {

        public int Id { get; set; }
        public int PageSectionId { get; set; }
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
        [Display(Name = "Title")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Display(Name = "Title description")]
        public string TitleDescription { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("PageSectionId")]
        public virtual SuPageSectionModel PageSection { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel PageLanguage { get; set; }


    }
}
