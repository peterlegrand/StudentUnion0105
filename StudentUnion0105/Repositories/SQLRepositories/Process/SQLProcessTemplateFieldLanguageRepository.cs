using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFieldLanguageRepository : IProcessTemplateFieldLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFieldLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFieldLanguageModel AddProcessTemplateFieldLanguage(SuProcessTemplateFieldLanguageModel suProcessTemplateFieldLanguage)
        {
            context.DbProcessTemplateFieldLanguage.Add(suProcessTemplateFieldLanguage);
            context.SaveChanges();
            return suProcessTemplateFieldLanguage;
        }

        public SuProcessTemplateFieldLanguageModel DeleteProcessTemplateFieldLanguage(int Id)
        {
            var suProcessTemplateFieldLanguage = context.DbProcessTemplateFieldLanguage.Find(Id);
            if (suProcessTemplateFieldLanguage != null)
            {
                context.DbProcessTemplateFieldLanguage.Remove(suProcessTemplateFieldLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateFieldLanguage;
        }

        public IEnumerable<SuProcessTemplateFieldLanguageModel> GetAllProcessTemplateFieldLanguages()
        {
            return context.DbProcessTemplateFieldLanguage;

        }

        public SuProcessTemplateFieldLanguageModel GetProcessTemplateFieldLanguage(int Id)
        {
            return context.DbProcessTemplateFieldLanguage.Find(Id);
        }

        public SuProcessTemplateFieldLanguageModel UpdateProcessTemplateFieldLanguage(SuProcessTemplateFieldLanguageModel suProcessTemplateFieldLanguageChanges)
        {
            var changedProcessTemplateFieldLanguage = context.DbProcessTemplateFieldLanguage.Attach(suProcessTemplateFieldLanguageChanges);
            changedProcessTemplateFieldLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFieldLanguageChanges;

        }
    }
}
