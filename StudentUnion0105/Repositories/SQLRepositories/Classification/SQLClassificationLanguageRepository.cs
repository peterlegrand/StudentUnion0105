using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationLanguageRepository : IClassificationLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuClassificationLanguageModel AddClassificationLanguage(SuClassificationLanguageModel suClassificationLanguage)
        {
            context.dbClassificationLanguage.Add(suClassificationLanguage);
            context.SaveChanges();
            return suClassificationLanguage;
        }

        public SuClassificationLanguageModel DeleteClassificationLanguage(int Id)
        {
            var suClassificationLanguage = context.dbClassificationLanguage.Find(Id);
            if (suClassificationLanguage != null)
            {
                context.dbClassificationLanguage.Remove(suClassificationLanguage);
                context.SaveChanges();

            }
            return suClassificationLanguage;

        }

        public IEnumerable<SuClassificationLanguageModel> GetAllClassificationLanguages()
        {
            return context.dbClassificationLanguage;
        }

        public SuClassificationLanguageModel GetClassificationLanguage(int Id)
        {
            return context.dbClassificationLanguage.Find(Id);
        }

        public SuClassificationLanguageModel UpdateClassificationLanguage(SuClassificationLanguageModel suClassificationLanguageChanges)
        {
            var suClassificationLanguage = context.dbClassificationLanguage.Attach(suClassificationLanguageChanges);
            suClassificationLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationLanguageChanges;
        }
    }
}
