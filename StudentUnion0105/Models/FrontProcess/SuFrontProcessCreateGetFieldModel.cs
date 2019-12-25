using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuFrontProcessCreateGetFieldModel
    {
        public int OId { get; set; }
        public int PId { get; set; }
        [Key]
        public int FieldId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        //public int DataTypeId { get; set; }
        //public int MasterListId { get; set; }
        public int ProcessTemplateFieldTypeId { get; set; }
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        [ForeignKey("PId")]
        public virtual SuFrontProcessCreateGetModel FrontProcess { get; set; }

    }
}
