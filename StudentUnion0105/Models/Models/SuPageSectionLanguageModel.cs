using StudentUnion0105.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuPageSectionLanguageModel
    {
        private readonly SuDbContext context;

        public SuPageSectionLanguageModel(SuDbContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }
        public int PageSectionId { get; set; }
        public int LanguageId { get; set; }
        public string PageSectionName { get; set; }
        public string PageSectionDescription { get; set; }
        public string PageSectionTitle { get; set; }
        public string PageSectionTitleDescription { get; set; }
        public string PageSectionMouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual SuPageSectionModel PageSection { get; set; }
        public virtual SuLanguageModel PageLanguage { get; set; }


    }
}
