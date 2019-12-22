using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontProcessTodoEditGetModel
    {
        public int PId { get; set; }
        public int FId { get; set; }
        [Key]
        public int PTFId { get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string MouseOver { get; set; }
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public int Sequence { get; set; }
        public int FieldDataTypeId { get; set; }
        public int FieldMasterListId { get; set; }
    }
}