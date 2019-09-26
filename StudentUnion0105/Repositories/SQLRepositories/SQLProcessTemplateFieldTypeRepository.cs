using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.dbProcessTemplateFieldType.Add(suProcessTemplateFieldType);
            context.SaveChanges();
            return suProcessTemplateFieldType;
        }

        public SuProcessTemplateFieldTypeModel DeleteProcessTemplateFieldType(int Id)
        {
           var suProcessTemplateFieldType =  context.dbProcessTemplateFieldType.Find(Id);
            if(suProcessTemplateFieldType != null)
            {
                context.dbProcessTemplateFieldType.Remove(suProcessTemplateFieldType);
                context.SaveChanges();

            }
            return suProcessTemplateFieldType;
        }

        public IEnumerable<SuProcessTemplateFieldTypeModel> GetAllProcessTemplateFieldTypes()
        {
            return context.dbProcessTemplateFieldType;
            
        }

        public SuProcessTemplateFieldTypeModel GetProcessTemplateFieldType(int Id)
        {
            return context.dbProcessTemplateFieldType.Find(Id);
        }

        public SuProcessTemplateFieldTypeModel UpdateProcessTemplateFieldType(SuProcessTemplateFieldTypeModel suProcessTemplateFieldTypeChanges)
        {
           var changedProcessTemplateFieldType = context.dbProcessTemplateFieldType.Attach(suProcessTemplateFieldTypeChanges);
            changedProcessTemplateFieldType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFieldTypeChanges;

        }
    }
}
