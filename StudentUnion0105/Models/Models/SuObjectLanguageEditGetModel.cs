using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuObjectLanguageEditGetModel
    {
        public int OId { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Key]
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string Language { get; set; }
    }
}