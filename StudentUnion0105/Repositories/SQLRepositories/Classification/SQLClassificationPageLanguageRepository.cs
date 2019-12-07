using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationPageLanguageRepository : IClassificationPageLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationPageLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuClassificationPageLanguageModel AddClassificationPageLanguage(SuClassificationPageLanguageModel suClassificationPageLanguage)
        {
            context.DbClassificationPageLanguage.Add(suClassificationPageLanguage);
            context.SaveChanges();
            return suClassificationPageLanguage;
        }

        public SuClassificationPageLanguageModel DeleteClassificationPageLanguage(int Id)
        {
            var suClassificationPageLanguage = context.DbClassificationPageLanguage.Find(Id);
            if (suClassificationPageLanguage != null)
            {
                context.DbClassificationPageLanguage.Remove(suClassificationPageLanguage);
                context.SaveChanges();

            }
            return suClassificationPageLanguage;

        }

        public IEnumerable<SuClassificationPageLanguageModel> GetAllClassificationPageLanguages()
        {
            return context.DbClassificationPageLanguage;//.AsNoTracking();
        }

        public SuClassificationPageLanguageModel GetClassificationPageLanguage(int Id)
        {
            return context.DbClassificationPageLanguage.Find(Id);
        }

        public SuClassificationPageLanguageModel UpdateClassificationPageLanguage(SuClassificationPageLanguageModel suClassificationPageLanguageChanges)
        {
            var suClassificationPageLanguage = context.DbClassificationPageLanguage.Attach(suClassificationPageLanguageChanges);
            suClassificationPageLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationPageLanguageChanges;
        }
    }
}
