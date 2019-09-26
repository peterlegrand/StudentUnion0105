using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
