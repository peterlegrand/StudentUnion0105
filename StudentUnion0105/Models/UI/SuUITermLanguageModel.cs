using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuUITermLanguageModel
    {
        public int Id { get; set; }
        public int TermId { get; set; }
        public int LanguageId { get; set; }
        public string Customization { get; set; }
        [ForeignKey("TermId")]
        public virtual SuUITermModel Term { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
