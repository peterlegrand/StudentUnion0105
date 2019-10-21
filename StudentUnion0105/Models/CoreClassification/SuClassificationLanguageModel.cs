using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Classification Id")]
        public int ClassificationId { get; set; }
        [Display(Name = "Language Id")]
        public int LanguageId { get; set; }
        [Display(Name = "Classification name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Classification description")]
        public string Description { get; set; }
        [MaxLength(50)]
        [Display(Name = "Classification menu name")]
        public string MenuName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Classification mouse over")]
        public string MouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ClassificationId")]
        public virtual SuClassificationModel Classification { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
