using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuClassificationLevelDeleteGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int Sequence { get; set; }
        public int DateLevel { get; set; }
        public bool OnTheFly { get; set; }
        public bool Alphabetically { get; set; }
        public bool CanLink { get; set; }
        public bool InDropDown { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
    }
}
