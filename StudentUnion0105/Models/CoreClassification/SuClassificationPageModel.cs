using StudentUnion0105.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageModel
    {
        private readonly SuDbContext context;

        public SuClassificationPageModel(SuDbContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }
        [Display(Name = "Classification id")]
        public int ClassificationId { get; set; }
        [Display(Name = "Classification page status id")]
        public int ClassificationPageStatusId { get; set; }
        [Display(Name = "Show classification title")]
        public bool ShowClassificationTitle { get; set; }
        [Display(Name = "Show classification title description")]
        public bool ShowClassificationTitleDescription { get; set; }
        [Display(Name = "Show classification page title")]
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationId")]
        public virtual SuClassificationModel Classification { get; set; }
        public virtual ICollection<SuClassificationPageLanguageModel> PageLanguages { get; set; }

    }
}
