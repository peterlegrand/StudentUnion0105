using StudentUnion0105.Data;
using System;
using System.Collections.Generic;
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
        public int ClassificationId { get; set; }
        public int ClassificationPageStatusId { get; set; }
        public bool ShowClassificationTitle { get; set; }
        public bool ShowClassificationTitleDescriptipn { get; set; }
        public bool ShowClassificationPageTitle { get; set; }
        public bool ShowClassificationPageTitleDescription { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationId")]
        public virtual SuClassificationModel Classification { get; set; }
        public virtual ICollection<SuClassificationPageLanguageModel> PageLanguages { get; set; }

    }
}
