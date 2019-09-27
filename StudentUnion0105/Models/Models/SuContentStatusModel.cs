using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuContentStatusModel
    {
        public int Id { get; set; }

        public string ContentStatusName { get; set; }

        public virtual ICollection<SuContentModel> Contents { get; set; }
    }
}
