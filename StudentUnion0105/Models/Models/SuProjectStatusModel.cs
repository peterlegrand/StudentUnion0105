using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuProjectStatusModel
    {
        public int Id { get; set; }
        public string ProjectStatusName { get; set; }

        public virtual ICollection<SuProjectModel> Projects { get; set; }

    }
}
