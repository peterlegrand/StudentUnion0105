using StudentUnion0105.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageLanguageModel
    {
        private readonly SuDbContext context;

        public SuClassificationPageLanguageModel(SuDbContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }
        public int ClassificationPageId { get; set; }
        public int LanguageId { get; set; }
        public string ClassificationPageName { get; set; }
        public string ClassificationPageDescription { get; set; }
        public string ClassificationPageMouseOver { get; set; }
        public string ClassificationPageTitle { get; set; }
        public string ClassificationPageTitleDescription { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationPageId")]
        public virtual SuClassificationPageModel ClassificationPage { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }


    }
}
