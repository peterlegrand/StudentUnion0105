using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.ViewModels
{
    public class SuObjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Menu name")]
        public string MenuName { get; set; }
        [Display(Name = "Mouse over")]
        public string MouseOver { get; set; }
        public int ObjectLanguageId { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        [Display(Name = "Has dropdown")]

        public bool HasDropDown  { get; set; }
        public string Language { get; set; }
        public int ObjectId { get; set; }
        [Display(Name = "Date level")]

        public bool DateLevel { get; set; }
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
        public string Title { get; set; }
        public string Description2 { get; set; }
        //public SuClassificationStatusModel StatusList { get; set; }
    }
}
