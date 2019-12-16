using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageDeleteGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int Status { get; set; }
        public bool ShowTitleName { get; set; }
        public bool ShowTitleDescription { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
    }
}
