using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

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
            context.DbProcessTemplate.Add(suProcessTemplate);
            context.SaveChanges();
            return suProcessTemplate;
        }

        public SuProcessTemplateModel DeleteProcessTemplate(int Id)
        {
            var suProcessTemplate = context.DbProcessTemplate.Find(Id);
            if (suProcessTemplate != null)
            {
                context.DbProcessTemplate.Remove(suProcessTemplate);
                context.SaveChanges();

            }
            return suProcessTemplate;
        }

        public IEnumerable<SuProcessTemplateModel> GetAllProcessTemplates()
        {
            return context.DbProcessTemplate;

        }

        public SuProcessTemplateModel GetProcessTemplate(int Id)
        {
            return context.DbProcessTemplate.Find(Id);
        }

        public SuProcessTemplateModel UpdateProcessTemplate(SuProcessTemplateModel suProcessTemplateChanges)
        {
            var changedProcessTemplate = context.DbProcessTemplate.Attach(suProcessTemplateChanges);
            changedProcessTemplate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateChanges;

        }
    }
}
