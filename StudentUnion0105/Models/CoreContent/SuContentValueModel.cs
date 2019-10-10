using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuContentValueModel
    {
        public int Id { get; set; }
        [Display(Name = "Content Id")]
        public int ContentId { get; set; }
        [Display(Name = "Classification value id")]
        public int ClassificationValueId { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ContentTypeId")]
        public virtual SuContentModel Content { get; set; }
        [ForeignKey("ClassificationValueId")]
        public virtual SuClassificationValueModel ClassificationValue { get; set; }

    }
}
