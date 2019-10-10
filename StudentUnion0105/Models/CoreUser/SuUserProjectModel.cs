using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuUserProjectModel
    {
        public int Id { get; set; }
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        [Display(Name = "Type Id")]
        public int TypeId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("UserId")]
        public virtual SuUserModel  User { get; set; }
        [ForeignKey("ProjectId")]
        public virtual SuProjectModel Project { get; set; }
        [ForeignKey("TypeId")]
        public virtual SuUserProjectTypeModel Type { get; set; }
    }
}
