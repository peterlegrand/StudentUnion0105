using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuMenu3LanguageModel
    {
        public int Id { get; set; }
        public int Menu3Id { get; set; }
        public int LanguageId { get; set; }
        [MaxLength(20)]
        public string MenuName { get; set; }
        [MaxLength(50)]
        public string MouseOver { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Menu1Id")]
        public virtual SuMenu3Model Menu3 { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
