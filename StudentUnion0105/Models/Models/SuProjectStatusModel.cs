using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuProjectStatusModel
    {
        public int Id { get; set; }
        public string ProjectStatusName { get; set; }

        public virtual ICollection<SuProjectModel> Projects { get; set; }

    }
}
