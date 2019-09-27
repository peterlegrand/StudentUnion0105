using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuSecurityLevelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SuContentModel> Contents { get; set; }
    }
}
