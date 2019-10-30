using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuObjectLanguageCreateGetModel
    {
        public int OId { get; set; }
        public int LanguageId { get; set; }
        [Key]
        public int LId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public string Description { get; set; }
        [Required] 
        public string MouseOver { get; set; }
        [Required] 
        public string MenuName { get; set; }
    }
}