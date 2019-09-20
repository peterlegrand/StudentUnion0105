using StudentUnion0105.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuPageSectionLanguageModel
    {

        public int Id { get; set; }
        public int PageSectionId { get; set; }
        public int LanguageId { get; set; }
        [Display(Name = "Name")]
        public string PageSectionName { get; set; }
        [Display(Name = "Description")]
        public string PageSectionDescription { get; set; }
        [Display(Name = "Title")]
        public string PageSectionTitle { get; set; }
        [Display(Name = "Title description")]
        public string PageSectionTitleDescription { get; set; }
        [Display(Name = "Mouse over")]
        public string PageSectionMouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("PageSectionId")]
        public virtual SuPageSectionModel PageSection { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel PageLanguage { get; set; }


    }
}
