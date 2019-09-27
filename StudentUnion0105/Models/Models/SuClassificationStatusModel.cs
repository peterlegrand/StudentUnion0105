using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuClassificationStatusModel
    {
        public int Id { get; set; }
        public string ClassificationStatusName { get; set; }

        public virtual ICollection<SuClassificationModel> Classifications { get; set; }
    }
}
