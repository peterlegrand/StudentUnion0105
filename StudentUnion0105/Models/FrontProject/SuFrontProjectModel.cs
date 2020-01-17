using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontProjectMyFrontProjectGetModel
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RelationName { get; set; }
    }
}
