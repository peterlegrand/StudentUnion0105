using StudentUnion0105.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageSectionLanguageModel
    {
        private readonly SuDbContext context;

        public SuClassificationPageSectionLanguageModel(SuDbContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }
        public int PageSectionId { get; set; }
        public int LanguageId { get; set; }
        public string ClassificationPageSectionName { get; set; }
        public string ClassificationPageSectionDescription { get; set; }
        public string ClassificationPageSectionTitle { get; set; }
        public string ClassificationPageSectionTitleDescription { get; set; }
        public string ClassificationPageSectionMouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual SuClassificationPageSectionModel PageSection { get; set; }
        public virtual SuLanguageModel PageLanguage { get; set; }


    }
}
