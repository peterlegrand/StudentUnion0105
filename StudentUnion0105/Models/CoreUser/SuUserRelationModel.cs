using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuUserRelationModel
    {
        public int Id { get; set; }
        [Display(Name = "From user Id")]
        [MaxLength(450)]
        public string FromUserId { get; set; }
        [Display(Name = "To user Id")]
        [MaxLength(450)]
        public string ToUserId { get; set; }
        [Display(Name = "Relation type Id")]
        public int TypeId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("FromUserId")]
        public virtual SuUserModel  FromUser { get; set; }
        [ForeignKey("ToUserId")]
        public virtual SuUserModel  ToUser { get; set; }
        [ForeignKey("TypeId")]
        public virtual SuUserRelationTypeModel Type { get; set; }
    }
}
