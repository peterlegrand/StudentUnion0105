using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuUserRelationTypeLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Type id")]
        public int TypeId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [MaxLength(50)]
        [Display(Name = "From is of To name")]
        public string FromIsOfToName { get; set; }
        [MaxLength(50)]
        [Display(Name = "To is of From name")]
        public string ToIsOfFromName { get; set; }
        [Display(Name = "From is of To description")]
        public string FromIsOfToDescription { get; set; }
        [Display(Name = "To is of From description")]
        public string ToIsOfFromDescription { get; set; }
        [MaxLength(50)]
        [Display(Name = "From is of To menu name")]
        public string FromIsOfToMenuName { get; set; }
        [MaxLength(50)]
        [Display(Name = "To is of From menu name")]
        public string ToIsOfFromMenuName { get; set; }
        [MaxLength(50)]
        [Display(Name = "From is of To mouse over")]
        public string FromIsOfToMouseOver { get; set; }
        [MaxLength(50)]
        [Display(Name = "To is of From mouse over")]
        public string ToIsOfFromMouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("TypeId")]
        public virtual SuUserRelationTypeModel Type { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
