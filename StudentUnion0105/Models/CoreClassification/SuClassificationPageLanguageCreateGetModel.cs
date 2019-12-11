using StudentUnion0105.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageLanguageCreateGetModel 
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
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }

    }
}
