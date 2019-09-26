using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFlowRepository
    {

        SuProcessTemplateFlowModel GetProcessTemplateFlow(int Id);
        IEnumerable<SuProcessTemplateFlowModel> GetAllProcessTemplateFlows();
        SuProcessTemplateFlowModel AddProcessTemplateFlow(SuProcessTemplateFlowModel suProcessTemplateFlow);
        SuProcessTemplateFlowModel UpdateProcessTemplateFlow(SuProcessTemplateFlowModel suProcessTemplateFlowChanges);
        SuProcessTemplateFlowModel DeleteProcessTemplateFlow(int Id);
    }
}
