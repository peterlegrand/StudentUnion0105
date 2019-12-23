using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFieldModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template id")]
        public int ProcessTemplateId { get; set; }
        public int ProcessTemplateFieldTypeId { get; set; }
        //[Display(Name = "field data type id")]
        //public int FieldDataTypeId { get; set; }
        //[Display(Name = "Field master list id")]
        ////PETER no idea what this is for.
        //public int FieldMasterListId { get; set; }
        [ForeignKey("ProcessTemplateId")]
        public virtual SuProcessTemplateModel ProcessTemplate { get; set; }
        [ForeignKey("ProcessTemplateFieldTypeId")]
        public virtual SuProcessTemplateFieldTypeModel ProcessTemplateFieldType { get; set; }
        //[ForeignKey("FieldDataTypeId")]
        //public virtual SuDataTypeModel DataType { get; set; }
        //[ForeignKey("FieldMasterListId")]
        //public virtual SuMasterListModel MasterList { get; set; }
        public virtual ICollection<SuProcessTemplateFieldLanguageModel> ProcessTemplateFieldLanguages { get; set; }
        public virtual ICollection<SuProcessTemplateStepFieldModel> ProcessTemplateFieldSteps { get; set; }


    }
}
