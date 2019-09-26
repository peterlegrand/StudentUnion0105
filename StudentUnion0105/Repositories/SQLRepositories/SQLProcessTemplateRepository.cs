using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateRepository : IProcessTemplateRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateModel AddProcessTemplate(SuProcessTemplateModel suProcessTemplate)
        {
            context.dbProcessTemplate.Add(suProcessTemplate);
            context.SaveChanges();
            return suProcessTemplate;
        }

        public SuProcessTemplateModel DeleteProcessTemplate(int Id)
        {
           var suProcessTemplate =  context.dbProcessTemplate.Find(Id);
            if(suProcessTemplate != null)
            {
                context.dbProcessTemplate.Remove(suProcessTemplate);
                context.SaveChanges();

            }
            return suProcessTemplate;
        }

        public IEnumerable<SuProcessTemplateModel> GetAllProcessTemplates()
        {
            return context.dbProcessTemplate;
            
        }

        public SuProcessTemplateModel GetProcessTemplate(int Id)
        {
            return context.dbProcessTemplate.Find(Id);
        }

        public SuProcessTemplateModel UpdateProcessTemplate(SuProcessTemplateModel suProcessTemplateChanges)
        {
           var changedProcessTemplate = context.dbProcessTemplate.Attach(suProcessTemplateChanges);
            changedProcessTemplate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateChanges;

        }
    }
}
