using System;

namespace StudentUnion0105.Models
{
    public class SuSettingModel
    {

        public int Id { get; set; }
        public int? IntValue { get; set; }
        public string StringValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public Guid? GuidValue { get; set; }
        public string SettingName { get; set; }
        public string SettingDescription { get; set; }
    }
}
