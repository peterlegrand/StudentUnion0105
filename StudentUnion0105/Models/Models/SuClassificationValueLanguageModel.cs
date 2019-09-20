using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuClassificationValueLanguageModel
    {
        public int Id { get; set; }
        public int ClassificationValueId { get; set; }
        public int LanguageId { get; set; }
        public string ClassificationValueName { get; set; }
        public string ClassificationValueDescription { get; set; }
        public string ClassificationValueDropDownName { get; set; }
        public string ClassificationValueMenuName { get; set; }
        public string ClassificationValueMouseOver { get; set; }
        public string ClassificationValuePageName { get; set; }
        public string ClassificationValuePageDescription { get; set; }
        public string ClassificationValueHeaderName { get; set; }
        public string ClassificationValueHeaderDescription { get; set; }
        public string ClassificationValueTopicName { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationValueId")]
        public virtual SuClassificationValueModel ClassificationValue { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
