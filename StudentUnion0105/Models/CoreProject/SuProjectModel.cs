using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProjectModel
    {
        public int Id { get; set; }
        [Display(Name = "Parent project id")]
        public int? ParentProjectId { get; set; }
        [Display(Name = "Project status id")]
        public int ProjectStatusId { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProjectStatusId")]
        public virtual SuProjectStatusModel ProjectStatus { get; set; }

    }
}
