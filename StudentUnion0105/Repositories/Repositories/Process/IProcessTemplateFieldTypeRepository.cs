using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFieldTypeRepository
    {
        SuProcessTemplateFieldTypeModel GetProcessTemplateFieldType(int Id);
        IEnumerable<SuProcessTemplateFieldTypeModel> GetAllProcessTemplateFieldTypes();
        SuProcessTemplateFieldTypeModel AddProcessTemplateFieldType(SuProcessTemplateFieldTypeModel suProcessTemplateFieldType);
        SuProcessTemplateFieldTypeModel UpdateProcessTemplateFieldType(SuProcessTemplateFieldTypeModel suProcessTemplateFieldTypeChanges);
        SuProcessTemplateFieldTypeModel DeleteProcessTemplateFieldType(int Id);
    }
}
