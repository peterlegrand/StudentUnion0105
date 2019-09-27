using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProjectModel
    {
        public int Id { get; set; }
        public int? ParentProjectId { get; set; }
        public int ProjectStatusId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProjectStatusId")]
        public virtual SuProjectStatusModel ProjectStatus { get; set; }

    }
}
