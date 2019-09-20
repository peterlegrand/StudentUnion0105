using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuClassificationLevelLanguageModel
    {
        public int Id { get; set; }
        public int ClassificationLevelId { get; set; }
        public int LanguageId { get; set; }
        public string ClassificationLevelName { get; set; }
        public string ClassificationLevelMenuName { get; set; }
        public string ClassificationLevelDescription { get; set; }
        public string ClassificationLevelMouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ClassificationLevelId")]

        public virtual SuClassificationLevelModel ClassificationLevel { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
