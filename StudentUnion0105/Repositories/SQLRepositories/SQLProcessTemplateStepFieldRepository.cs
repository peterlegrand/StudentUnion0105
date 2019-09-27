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
            context.dbProcessTemplateStepField.Add(suProcessTemplateStepField);
            context.SaveChanges();
            return suProcessTemplateStepField;
        }

        public SuProcessTemplateStepFieldModel DeleteProcessTemplateStepField(int Id)
        {
            var suProcessTemplateStepField = context.dbProcessTemplateStepField.Find(Id);
            if (suProcessTemplateStepField != null)
            {
                context.dbProcessTemplateStepField.Remove(suProcessTemplateStepField);
                context.SaveChanges();

            }
            return suProcessTemplateStepField;
        }

        public IEnumerable<SuProcessTemplateStepFieldModel> GetAllProcessTemplateStepFields()
        {
            return context.dbProcessTemplateStepField;

        }

        public SuProcessTemplateStepFieldModel GetProcessTemplateStepField(int Id)
        {
            return context.dbProcessTemplateStepField.Find(Id);
        }

        public SuProcessTemplateStepFieldModel UpdateProcessTemplateStepField(SuProcessTemplateStepFieldModel suProcessTemplateStepFieldChanges)
        {
            var changedProcessTemplateStepField = context.dbProcessTemplateStepField.Attach(suProcessTemplateStepFieldChanges);
            changedProcessTemplateStepField.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateStepFieldChanges;

        }
    }
}
