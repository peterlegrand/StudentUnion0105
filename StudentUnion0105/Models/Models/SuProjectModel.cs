using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuProjectModel
    {
        public int Id { get; set; }
        public int ParentProjectId { get; set; }
        public int ProjectStatusId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual SuProjectStatusModel ProjectStatus { get; set; }
        
    }
}
