using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateStepFieldRepository : IProcessTemplateStepFieldRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateStepFieldRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateStepFieldModel AddProcessTemplateStepField(SuProcessTemplateStepFieldModel suProcessTemplateStepField)
        {
            context.DbProcessTemplateStepField.Add(suProcessTemplateStepField);
            context.SaveChanges();
            return suProcessTemplateStepField;
        }

        public SuProcessTemplateStepFieldModel DeleteProcessTemplateStepField(int Id)
        {
            var suProcessTemplateStepField = context.DbProcessTemplateStepField.Find(Id);
            if (suProcessTemplateStepField != null)
            {
                context.DbProcessTemplateStepField.Remove(suProcessTemplateStepField);
                context.SaveChanges();

            }
            return suProcessTemplateStepField;
        }

        public IEnumerable<SuProcessTemplateStepFieldModel> GetAllProcessTemplateStepFields()
        {
            return context.DbProcessTemplateStepField;

        }

        public SuProcessTemplateStepFieldModel GetProcessTemplateStepField(int Id)
        {
            return context.DbProcessTemplateStepField.Find(Id);
        }

        public SuProcessTemplateStepFieldModel UpdateProcessTemplateStepField(SuProcessTemplateStepFieldModel suProcessTemplateStepFieldChanges)
        {
            var changedProcessTemplateStepField = context.DbProcessTemplateStepField.Attach(suProcessTemplateStepFieldChanges);
            changedProcessTemplateStepField.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateStepFieldChanges;

        }
    }
}
