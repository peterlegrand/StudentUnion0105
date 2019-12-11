using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationLevelLanguageModel
    {
        public int Id { get; set; }
        public int ClassificationLevelId { get; set; }
        public int LanguageId { get; set; }
        [Display(Name = "Classification level name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Classification level menu name")]
        public string Description { get; set; }
        [Display(Name = "Classification level menu name")]
        [MaxLength(50)]
        public string MenuName { get; set; }

        [Display(Name = "Classification level mouse over")]
        [MaxLength(50)]
        public string MouseOver { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ClassificationLevelId")]

        public virtual SuClassificationLevelModel ClassificationLevel { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
