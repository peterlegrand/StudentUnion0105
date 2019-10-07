using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFieldModel
    {
        public int Id { get; set; }
        public int ProcessTemplateId { get; set; }
        public int FieldDataTypeId { get; set; }
        public int FieldMasterListId { get; set; }
        [ForeignKey("ProcessTemplateId")]
        public virtual SuProcessTemplateModel ProcessTemplate { get; set; }
        [ForeignKey("FieldDataTypeId")]
        public virtual SuDataTypeModel DataType { get; set; }
        [ForeignKey("FieldMasterListId")]
        public virtual SuMasterListModel MasterList { get; set; }
        public virtual ICollection<SuProcessTemplateFieldLanguageModel> ProcessTemplateFieldLanguages { get; set; }
        public virtual ICollection<SuProcessTemplateStepFieldModel> ProcessTemplateFieldSteps { get; set; }


    }
}
