using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuObjectLanguageIndexGetModel
    {
        public int OId { get; set; }
        [Key]
        public int LId { get; set; }
        public int PId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
    }

    public class LanguageCreateGetLanguageList
    {
        [Key]
        public string Value { get; set; }
        public string Text { get; set; }
    }
}