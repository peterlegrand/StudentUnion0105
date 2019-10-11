using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateLanguageRepository : IProcessTemplateLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateLanguageModel AddProcessTemplateLanguage(SuProcessTemplateLanguageModel suProcessTemplateLanguage)
        {
            context.dbProcessTemplateLanguage.Add(suProcessTemplateLanguage);
            context.SaveChanges();
            return suProcessTemplateLanguage;
        }

        public SuProcessTemplateLanguageModel DeleteProcessTemplateLanguage(int Id)
        {
            var suProcessTemplateLanguage = context.dbProcessTemplateLanguage.Find(Id);
            if (suProcessTemplateLanguage != null)
            {
                context.dbProcessTemplateLanguage.Remove(suProcessTemplateLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateLanguage;
        }

        public IEnumerable<SuProcessTemplateLanguageModel> GetAllProcessTemplateLanguages()
        {
            return context.dbProcessTemplateLanguage;

        }

        public SuProcessTemplateLanguageModel GetProcessTemplateLanguage(int Id)
        {
            return context.dbProcessTemplateLanguage.Find(Id);
        }

        public SuProcessTemplateLanguageModel UpdateProcessTemplateLanguage(SuProcessTemplateLanguageModel suProcessTemplateLanguageChanges)
        {
            var changedProcessTemplateLanguage = context.dbProcessTemplateLanguage.Attach(suProcessTemplateLanguageChanges);
            changedProcessTemplateLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateLanguageChanges;

        }
    }
}
