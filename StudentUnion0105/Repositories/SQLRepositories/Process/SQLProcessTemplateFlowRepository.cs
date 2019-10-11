using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFlowRepository : IProcessTemplateFlowRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFlowRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFlowModel AddProcessTemplateFlow(SuProcessTemplateFlowModel suProcessTemplateFlow)
        {
            context.dbProcessTemplateFlow.Add(suProcessTemplateFlow);
            context.SaveChanges();
            return suProcessTemplateFlow;
        }

        public SuProcessTemplateFlowModel DeleteProcessTemplateFlow(int Id)
        {
            var suProcessTemplateFlow = context.dbProcessTemplateFlow.Find(Id);
            if (suProcessTemplateFlow != null)
            {
                context.dbProcessTemplateFlow.Remove(suProcessTemplateFlow);
                context.SaveChanges();

            }
            return suProcessTemplateFlow;
        }

        public IEnumerable<SuProcessTemplateFlowModel> GetAllProcessTemplateFlows()
        {
            return context.dbProcessTemplateFlow;

        }

        public SuProcessTemplateFlowModel GetProcessTemplateFlow(int Id)
        {
            return context.dbProcessTemplateFlow.Find(Id);
        }

        public SuProcessTemplateFlowModel UpdateProcessTemplateFlow(SuProcessTemplateFlowModel suProcessTemplateFlowChanges)
        {
            var changedProcessTemplateFlow = context.dbProcessTemplateFlow.Attach(suProcessTemplateFlowChanges);
            changedProcessTemplateFlow.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFlowChanges;

        }
    }
}
