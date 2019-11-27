using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFieldTypeLanguageRepository : IProcessTemplateFieldTypeLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFieldTypeLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFieldTypeLanguageModel AddProcessTemplateFieldTypeLanguage(SuProcessTemplateFieldTypeLanguageModel suProcessTemplateFieldTypeLanguage)
        {
            context.DbProcessTemplateFieldTypeLanguage.Add(suProcessTemplateFieldTypeLanguage);
            context.SaveChanges();
            return suProcessTemplateFieldTypeLanguage;
        }

        public SuProcessTemplateFieldTypeLanguageModel DeleteProcessTemplateFieldTypeLanguage(int Id)
        {
            var suProcessTemplateFieldTypeLanguage = context.DbProcessTemplateFieldTypeLanguage.Find(Id);
            if (suProcessTemplateFieldTypeLanguage != null)
            {
                context.DbProcessTemplateFieldTypeLanguage.Remove(suProcessTemplateFieldTypeLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateFieldTypeLanguage;
        }

        public IEnumerable<SuProcessTemplateFieldTypeLanguageModel> GetAllProcessTemplateFieldTypeLanguages()
        {
            return context.DbProcessTemplateFieldTypeLanguage;

        }

        public SuProcessTemplateFieldTypeLanguageModel GetProcessTemplateFieldTypeLanguage(int Id)
        {
            return context.DbProcessTemplateFieldTypeLanguage.Find(Id);
        }

        public SuProcessTemplateFieldTypeLanguageModel UpdateProcessTemplateFieldTypeLanguage(SuProcessTemplateFieldTypeLanguageModel suProcessTemplateFieldTypeLanguageChanges)
        {
            var changedProcessTemplateFieldTypeLanguage = context.DbProcessTemplateFieldTypeLanguage.Attach(suProcessTemplateFieldTypeLanguageChanges);
            changedProcessTemplateFieldTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFieldTypeLanguageChanges;

        }
    }
}
