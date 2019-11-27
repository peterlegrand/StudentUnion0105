using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFieldTypeRepository : IProcessTemplateFieldTypeRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFieldTypeRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFieldTypeModel AddProcessTemplateFieldType(SuProcessTemplateFieldTypeModel suProcessTemplateFieldType)
        {
            context.DbProcessTemplateFieldType.Add(suProcessTemplateFieldType);
            context.SaveChanges();
            return suProcessTemplateFieldType;
        }

        public SuProcessTemplateFieldTypeModel DeleteProcessTemplateFieldType(int Id)
        {
            var suProcessTemplateFieldType = context.DbProcessTemplateFieldType.Find(Id);
            if (suProcessTemplateFieldType != null)
            {
                context.DbProcessTemplateFieldType.Remove(suProcessTemplateFieldType);
                context.SaveChanges();

            }
            return suProcessTemplateFieldType;
        }

        public IEnumerable<SuProcessTemplateFieldTypeModel> GetAllProcessTemplateFieldTypes()
        {
            return context.DbProcessTemplateFieldType;

        }

        public SuProcessTemplateFieldTypeModel GetProcessTemplateFieldType(int Id)
        {
            return context.DbProcessTemplateFieldType.Find(Id);
        }

        public SuProcessTemplateFieldTypeModel UpdateProcessTemplateFieldType(SuProcessTemplateFieldTypeModel suProcessTemplateFieldTypeChanges)
        {
            var changedProcessTemplateFieldType = context.DbProcessTemplateFieldType.Attach(suProcessTemplateFieldTypeChanges);
            changedProcessTemplateFieldType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFieldTypeChanges;

        }
    }
}
