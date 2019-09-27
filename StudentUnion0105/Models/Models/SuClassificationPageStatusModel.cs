using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageStatusModel
    {
        public int Id { get; set; }
        public string ClassificationPageStatusName { get; set; }
        public virtual ICollection<SuClassificationPageModel> ClassificationPages { get; set; }

    }
}
