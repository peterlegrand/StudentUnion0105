using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFieldEditGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int LId { get; set; }
        public int LanguageId { get; set; }
        public int ProcessTemplateFieldTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }

    }
}
