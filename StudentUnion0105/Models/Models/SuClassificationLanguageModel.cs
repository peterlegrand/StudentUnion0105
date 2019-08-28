using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuClassificationLanguageModel
    {
        public int Id { get; set; }
        public int ClassificationId { get; set; }
        public int LanguageId { get; set; }
        public string ClassificationName { get; set; }
        public string ClassificationMenuName { get; set; }
        public string ClassificationMouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual SuClassificationModel Classification { get; set; }
        public virtual SuLanguageModel Language { get; set; }
    }
}
