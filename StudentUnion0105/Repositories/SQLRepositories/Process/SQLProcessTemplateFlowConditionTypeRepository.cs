using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFlowConditionTypeRepository : IProcessTemplateFlowConditionTypeRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFlowConditionTypeRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFlowConditionTypeModel AddProcessTemplateFlowConditionType(SuProcessTemplateFlowConditionTypeModel suProcessTemplateFlowConditionType)
        {
            context.DbProcessTemplateFlowConditionType.Add(suProcessTemplateFlowConditionType);
            context.SaveChanges();
            return suProcessTemplateFlowConditionType;
        }

        public SuProcessTemplateFlowConditionTypeModel DeleteProcessTemplateFlowConditionType(int Id)
        {
            var suProcessTemplateFlowConditionType = context.DbProcessTemplateFlowConditionType.Find(Id);
            if (suProcessTemplateFlowConditionType != null)
            {
                context.DbProcessTemplateFlowConditionType.Remove(suProcessTemplateFlowConditionType);
                context.SaveChanges();

            }
            return suProcessTemplateFlowConditionType;
        }

        public IEnumerable<SuProcessTemplateFlowConditionTypeModel> GetAllProcessTemplateFlowConditionTypes()
        {
            return context.DbProcessTemplateFlowConditionType;

        }

        public SuProcessTemplateFlowConditionTypeModel GetProcessTemplateFlowConditionType(int Id)
        {
            return context.DbProcessTemplateFlowConditionType.Find(Id);
        }

        public SuProcessTemplateFlowConditionTypeModel UpdateProcessTemplateFlowConditionType(SuProcessTemplateFlowConditionTypeModel suProcessTemplateFlowConditionTypeChanges)
        {
            var changedProcessTemplateFlowConditionType = context.DbProcessTemplateFlowConditionType.Attach(suProcessTemplateFlowConditionTypeChanges);
            changedProcessTemplateFlowConditionType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFlowConditionTypeChanges;

        }
    }
}
