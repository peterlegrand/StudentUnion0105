using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuMenu3Model
    {
        public int Id { get; set; }
        public int Menu2Id { get; set; }
        public int MenuTypeId { get; set; }
        public int Sequence { get; set; }
        public int ClassificationId { get; set; }
        public int FeatureId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int DestinationId { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuMenu3LanguageModel> Menu3Languages { get; set; }
        [ForeignKey("Menu2Id")]
        public virtual SuMenu2Model Menu2 { get; set; }
        [ForeignKey("MenuTypeId")]
        public virtual SuMenuTypeModel MenuType { get; set; }
    }
}
