using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateRepository
    {

        SuProcessTemplateModel GetProcessTemplate(int Id);
        IEnumerable<SuProcessTemplateModel> GetAllProcessTemplates();
        SuProcessTemplateModel AddProcessTemplate(SuProcessTemplateModel suProcessTemplate);
        SuProcessTemplateModel UpdateProcessTemplate(SuProcessTemplateModel suProcessTemplateChanges);
        SuProcessTemplateModel DeleteProcessTemplate(int Id);
    }
}
