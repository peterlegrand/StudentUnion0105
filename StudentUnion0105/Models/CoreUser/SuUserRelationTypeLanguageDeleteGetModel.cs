using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuUserRelationTypeLanguageDeleteGetModel
    {
        [Key]
        public int LId { get; set; }
        public string FromIsOfToName { get; set; }
        public string ToIsOfFromName { get; set; }
        [Required]
        public string FromIsOfToDescription { get; set; }
        [Required]
        public string ToIsOfFromDescription { get; set; }
        public string FromIsOfToMouseOver { get; set; }
        [Required]
        public string ToIsOfFromMouseOver { get; set; }
        [Required]
        public string FromIsOfToMenuName { get; set; }
        [Required]
        public string ToIsOfFromMenuName { get; set; }
        public string Language { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}