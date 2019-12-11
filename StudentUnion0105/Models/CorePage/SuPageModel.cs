using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPageModel
    {
        public int Id { get; set; }
        [Display(Name = "Page status id")]
        public int PageStatusId { get; set; }
        [Display(Name = "Page type id")]
        public int PageTypeId { get; set; }
        public bool ShowTitleName { get; set; }
        public bool ShowTitleDescription { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("PageStatusId")]
        public virtual SuPageStatusModel PageStatus { get; set; }
        [ForeignKey("PageTypeId")]
        public virtual SuPageTypeModel PageType { get; set; }
        public virtual ICollection<SuPageLanguageModel> PageLanguages { get; set; }
        public virtual ICollection<SuPageSectionModel> PageSections { get; set; }

    }
}
