using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuPageStatusModel
    {
        public int Id { get; set; }
        public string PageStatusName { get; set; }
        public virtual ICollection<SuPageModel> Organization { get; set; }

    }
}
