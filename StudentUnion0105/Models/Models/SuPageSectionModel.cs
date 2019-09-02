using StudentUnion0105.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuPageSectionModel
    {
        private readonly SuDbContext contect;

        public SuPageSectionModel(SuDbContext contect)
        {
            this.contect = contect;
        }

        public int Id { get; set; }
        public int PageId { get; set; }
        public int Sequence { get; set; }
        public int PageSectionTypeId { get; set; }
        public bool ShowSectionTitle { get; set; }
        public bool ShowSectionTitleDescription { get; set; }
        public bool ShowContentTypeTitle { get; set; }
        public bool ShowContentTypeDescription { get; set; }
        public int OneTwoColumns { get; set; }
        public int ContentTypeId { get; set; }
        public int SortById { get; set; }
        public int MaxContent { get; set; }
        public bool HasPaging { get; set; }
        public virtual SuPageModel Page { get; set; }
        public virtual SuPageSectionTypeModel PageSectionType { get; set; }
        public virtual SuContentTypeModel ContentType { get; set; }

        public virtual ICollection<SuPageSectionLanguageModel> PageSectionLanguages { get; set; }



    }
}
