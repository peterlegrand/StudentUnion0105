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
            context.DbClassificationLanguage.Add(suClassificationLanguage);
            context.SaveChanges();
            return suClassificationLanguage;
        }

        public SuClassificationLanguageModel DeleteClassificationLanguage(int Id)
        {
            var suClassificationLanguage = context.DbClassificationLanguage.Find(Id);
            if (suClassificationLanguage != null)
            {
                context.DbClassificationLanguage.Remove(suClassificationLanguage);
                context.SaveChanges();

            }
            return suClassificationLanguage;

        }

        public IEnumerable<SuClassificationLanguageModel> GetAllClassificationLanguages()
        {
            return context.DbClassificationLanguage;
        }

        public SuClassificationLanguageModel GetClassificationLanguage(int Id)
        {
            return context.DbClassificationLanguage.Find(Id);
        }

        public SuClassificationLanguageModel UpdateClassificationLanguage(SuClassificationLanguageModel suClassificationLanguageChanges)
        {
            var suClassificationLanguage = context.DbClassificationLanguage.Attach(suClassificationLanguageChanges);
            suClassificationLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationLanguageChanges;
        }
    }
}
