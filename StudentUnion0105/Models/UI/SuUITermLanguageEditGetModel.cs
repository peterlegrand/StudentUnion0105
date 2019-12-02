using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuUITermLanguageEditGetModel
    {
        public int Id { get; set; }
        public string Customization { get; set; }
        public int TermId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Name { get; set; }

    }
}