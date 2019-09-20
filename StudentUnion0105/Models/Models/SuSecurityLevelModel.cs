using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuSecurityLevelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SuContentModel> Contents { get; set; }
    }
}
