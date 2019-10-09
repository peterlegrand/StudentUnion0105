using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuSettingModel
    {

        public int Id { get; set; }
        [Display(Name = "Int value")]
        public int? IntValue { get; set; }
        [Display(Name = "String value")]
        public string StringValue { get; set; }
        [Display(Name = "Date time value")]
        public DateTime? DateTimeValue { get; set; }
        [Display(Name = "Guid value")]
        public Guid? GuidValue { get; set; }
        [Display(Name = "Setting Name")]
        public string SettingName { get; set; }
        [Display(Name = "Setting description")]
        public string SettingDescription { get; set; }
    }
}
