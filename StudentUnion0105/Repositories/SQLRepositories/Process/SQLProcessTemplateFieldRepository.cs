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
            context.DbProcessTemplateField.Add(suProcessTemplateField);
            context.SaveChanges();
            return suProcessTemplateField;
        }

        public SuProcessTemplateFieldModel DeleteProcessTemplateField(int Id)
        {
            var suProcessTemplateField = context.DbProcessTemplateField.Find(Id);
            if (suProcessTemplateField != null)
            {
                context.DbProcessTemplateField.Remove(suProcessTemplateField);
                context.SaveChanges();

            }
            return suProcessTemplateField;
        }

        public IEnumerable<SuProcessTemplateFieldModel> GetAllProcessTemplateFields()
        {
            return context.DbProcessTemplateField;

        }

        public SuProcessTemplateFieldModel GetProcessTemplateField(int Id)
        {
            return context.DbProcessTemplateField.Find(Id);
        }

        public SuProcessTemplateFieldModel UpdateProcessTemplateField(SuProcessTemplateFieldModel suProcessTemplateFieldChanges)
        {
            var changedProcessTemplateField = context.DbProcessTemplateField.Attach(suProcessTemplateFieldChanges);
            changedProcessTemplateField.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFieldChanges;

        }
    }
}
