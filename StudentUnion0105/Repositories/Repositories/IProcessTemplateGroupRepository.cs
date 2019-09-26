using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateGroupRepository
    {
        SuProcessTemplateGroupModel GetProcessTemplateGroup(int Id);
        IEnumerable<SuProcessTemplateGroupModel> GetAllProcessTemplateGroups();
        SuProcessTemplateGroupModel AddProcessTemplateGroup(SuProcessTemplateGroupModel suProcessTemplateGroup);
        SuProcessTemplateGroupModel UpdateProcessTemplateGroup(SuProcessTemplateGroupModel suProcessTemplateGroupChanges);
        SuProcessTemplateGroupModel DeleteProcessTemplateGroup(int Id);
    }
}
