using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationLevelModel
    {
        public int Id { get; set; }
        public int ClassificationId { get; set; }
        public int Sequence { get; set; }
        //0 is no date level 
        //1 is date
        //2 is date range
        //3 is date time
        //4 is date time range
        [Display(Name = "Date level")]
        public int DateLevel { get; set; }
        [Display(Name = "On the fly")]
        public bool OnTheFly { get; set; }
        public bool Alphabetically { get; set; }
        [Display(Name = "Can link")]
        public bool CanLink { get; set; }
        [Display(Name = "In dropdown")]
        public bool InDropDown { get; set; }
        public bool InMenu { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationId")]
        public virtual SuClassificationModel Classification { get; set; }
        public virtual ICollection<SuClassificationLevelLanguageModel> ClassificationLevelLanguages { get; set; }

    }
}
