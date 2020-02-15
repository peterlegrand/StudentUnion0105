using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuObjectIndexGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
    }
    public class SuObjectIndexGetModel2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
    }
}