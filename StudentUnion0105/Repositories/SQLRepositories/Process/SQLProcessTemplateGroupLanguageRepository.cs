using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateGroupLanguageRepository : IProcessTemplateGroupLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateGroupLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateGroupLanguageModel AddProcessTemplateGroupLanguage(SuProcessTemplateGroupLanguageModel suProcessTemplateGroupLanguage)
        {
            context.DbProcessTemplateGroupLanguage.Add(suProcessTemplateGroupLanguage);
            context.SaveChanges();
            return suProcessTemplateGroupLanguage;
        }

        public SuProcessTemplateGroupLanguageModel DeleteProcessTemplateGroupLanguage(int Id)
        {
            var suProcessTemplateGroupLanguage = context.DbProcessTemplateGroupLanguage.Find(Id);
            if (suProcessTemplateGroupLanguage != null)
            {
                context.DbProcessTemplateGroupLanguage.Remove(suProcessTemplateGroupLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateGroupLanguage;
        }

        public IEnumerable<SuProcessTemplateGroupLanguageModel> GetAllProcessTemplateGroupLanguages()
        {
            return context.DbProcessTemplateGroupLanguage;

        }

        public SuProcessTemplateGroupLanguageModel GetProcessTemplateGroupLanguage(int Id)
        {
            return context.DbProcessTemplateGroupLanguage.Find(Id);
        }

        public SuProcessTemplateGroupLanguageModel UpdateProcessTemplateGroupLanguage(SuProcessTemplateGroupLanguageModel suProcessTemplateGroupLanguageChanges)
        {
            var changedProcessTemplateGroupLanguage = context.DbProcessTemplateGroupLanguage.Attach(suProcessTemplateGroupLanguageChanges);
            changedProcessTemplateGroupLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateGroupLanguageChanges;

        }
    }
}
