using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontRelationMyFrontRelationGetModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RelationName { get; set; }
    }
}
