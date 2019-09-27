using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.ViewModels
{
    public class SuObjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Menu name")]
        public string MenuName { get; set; }
        [Display(Name = "Mouse over")]
        public string MouseOver { get; set; }
        public int ObjectLanguageId { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        [Display(Name = "Has dropdown")]

        public bool HasDropDown { get; set; }
        public string Language { get; set; }
        public int ObjectId { get; set; }
        [Display(Name = "Date level")]

        public int DateLevel { get; set; }
        [Display(Name = "On the fly")]
        public bool OnTheFly { get; set; }
        public bool Alphabetically { get; set; }
        [Display(Name = "Can link")]
        public bool CanLink { get; set; }
        [Display(Name = "In drop down")]

        public bool InDropDown { get; set; }
        public int LanguageId { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; }
        public int? NullId { get; set; }
        public int NotNullId { get; set; }
        public string Title { get; set; }
        public string Description2 { get; set; }

        public string DropDownName { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string HeaderName { get; set; }
        public string HeaderDescription { get; set; }
        public string TopicName { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
        //public SuClassificationStatusModel StatusList { get; set; }
        public int Level { get; set; }
        public bool IndexSection { get; set; }

    }
}
