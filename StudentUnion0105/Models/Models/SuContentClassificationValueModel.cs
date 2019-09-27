using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuContentClassificationValueModel
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int ClassificationValueId { get; set; }
        [ForeignKey("ClassificationValueId")]
        public virtual SuClassificationValueModel ClassificationValue { get; set; }
        [ForeignKey("ContentId")]
        public virtual SuContentModel Content { get; set; }

    }
}
