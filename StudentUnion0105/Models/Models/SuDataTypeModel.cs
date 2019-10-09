using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuDataTypeModel
    {
        public int Id { get; set; }
        [Display(Name = "Data type name")]
        [MaxLength(50)]
        public string DataTypeName { get; set; }
        [Display(Name = "Data type description")]
        public string DataTypeDescription { get; set; }

    }
}
