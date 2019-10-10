using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuUITermScreenModel
    {
        public int Id { get; set; }
        public int TermId { get; set; }
        public int ScreenId { get; set; }
        public int Sequence { get; set; }
        [ForeignKey("TermId")]
        public virtual SuUITermModel Term { get; set; }
        [ForeignKey("ScreenId")]
        public virtual SuUIScreenModel Screen { get; set; }


    }
}
