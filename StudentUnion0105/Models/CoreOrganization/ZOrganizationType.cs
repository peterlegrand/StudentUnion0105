using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuOrganizationTypeDeleteGetModel
    {
        public int Id { get; set; }
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
    public class SuOrganizationTypeEditGetModel
    {
        public int Id { get; set; }
        public int Lid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
}
