using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFlowConditionRepository : IProcessTemplateFlowConditionRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFlowConditionRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFlowConditionModel AddProcessTemplateFlowCondition(SuProcessTemplateFlowConditionModel suProcessTemplateFlowCondition)
        {
            context.dbProcessTemplateFlowCondition.Add(suProcessTemplateFlowCondition);
            context.SaveChanges();
            return suProcessTemplateFlowCondition;
        }

        public SuProcessTemplateFlowConditionModel DeleteProcessTemplateFlowCondition(int Id)
        {
            var suProcessTemplateFlowCondition = context.dbProcessTemplateFlowCondition.Find(Id);
            if (suProcessTemplateFlowCondition != null)
            {
                context.dbProcessTemplateFlowCondition.Remove(suProcessTemplateFlowCondition);
                context.SaveChanges();

            }
            return suProcessTemplateFlowCondition;
        }

        public IEnumerable<SuProcessTemplateFlowConditionModel> GetAllProcessTemplateFlowConditions()
        {
            return context.dbProcessTemplateFlowCondition;

        }

        public SuProcessTemplateFlowConditionModel GetProcessTemplateFlowCondition(int Id)
        {
            return context.dbProcessTemplateFlowCondition.Find(Id);
        }

        public SuProcessTemplateFlowConditionModel UpdateProcessTemplateFlowCondition(SuProcessTemplateFlowConditionModel suProcessTemplateFlowConditionChanges)
        {
            var changedProcessTemplateFlowCondition = context.dbProcessTemplateFlowCondition.Attach(suProcessTemplateFlowConditionChanges);
            changedProcessTemplateFlowCondition.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFlowConditionChanges;

        }
    }
}
