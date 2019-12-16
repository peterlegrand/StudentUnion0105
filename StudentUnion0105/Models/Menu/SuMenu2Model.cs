using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuMenu2Model
    {
        public int Id { get; set; }
        public int Menu1Id { get; set; }
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

        public virtual ICollection<SuMenu2LanguageModel> Menu2Languages { get; set; }
        public virtual ICollection<SuMenu3Model> Menu3 { get; set; }
        [ForeignKey("Menu1Id")]
        public virtual SuMenu1Model Menu1 { get; set; }
        [ForeignKey("MenuTypeId")]
        public virtual SuMenuTypeModel MenuType { get; set; }
    }
}
