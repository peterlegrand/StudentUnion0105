using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuUserRelationTypeIndexGetModel
    {
        [Key]
        public int OId { get; set; }
        public string FromIsOfToName { get; set; }
        public string ToIsOfFromName { get; set; }
        public string FromIsOfToDescription { get; set; }
        public string ToIsOfFromDescription { get; set; }
        public string FromIsOfToMouseOver { get; set; }
        public string ToIsOfFromMouseOver { get; set; }
        public string FromIsOfToMenuName { get; set; }
        public string ToIsOfFromMenuName { get; set; }
    }
}