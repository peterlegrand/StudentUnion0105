using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFieldRepository : IProcessTemplateFieldRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFieldRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFieldModel AddProcessTemplateField(SuProcessTemplateFieldModel suProcessTemplateField)
        {
            context.dbProcessTemplateField.Add(suProcessTemplateField);
            context.SaveChanges();
            return suProcessTemplateField;
        }

        public SuProcessTemplateFieldModel DeleteProcessTemplateField(int Id)
        {
            var suProcessTemplateField = context.dbProcessTemplateField.Find(Id);
            if (suProcessTemplateField != null)
            {
                context.dbProcessTemplateField.Remove(suProcessTemplateField);
                context.SaveChanges();

            }
            return suProcessTemplateField;
        }

        public IEnumerable<SuProcessTemplateFieldModel> GetAllProcessTemplateFields()
        {
            return context.dbProcessTemplateField;

        }

        public SuProcessTemplateFieldModel GetProcessTemplateField(int Id)
        {
            return context.dbProcessTemplateField.Find(Id);
        }

        public SuProcessTemplateFieldModel UpdateProcessTemplateField(SuProcessTemplateFieldModel suProcessTemplateFieldChanges)
        {
            var changedProcessTemplateField = context.dbProcessTemplateField.Attach(suProcessTemplateFieldChanges);
            changedProcessTemplateField.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFieldChanges;

        }
    }
}
