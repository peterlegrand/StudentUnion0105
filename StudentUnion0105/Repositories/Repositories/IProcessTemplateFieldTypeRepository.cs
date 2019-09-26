using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
