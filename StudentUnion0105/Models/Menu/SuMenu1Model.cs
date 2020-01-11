using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuMenu1Model
    {
        public int Id { get; set; }
        public int MenuTypeId { get; set; }
        public int Sequence { get; set; }
        public int ClassificationId { get; set; }
        public int FeatureId { get; set; }
        [MaxLength(20)]
        public string Controller { get; set; }
        [MaxLength(20)]
        public string Action { get; set; }
        public int DestinationId { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuMenu2Model> Menu2 { get; set; }
        public virtual ICollection<SuMenu1LanguageModel> Menu1Languages { get; set; }
        [ForeignKey("MenuTypeId")]
        public virtual SuMenuTypeModel MenuType { get; set; }
    }
}
