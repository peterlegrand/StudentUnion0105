using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuClassificationStatusModel
    {
        public int Id { get; set; }
        public string ClassificationStatusName { get; set; }

        public virtual ICollection<SuClassificationModel> Classifications { get; set; }
    }
}
