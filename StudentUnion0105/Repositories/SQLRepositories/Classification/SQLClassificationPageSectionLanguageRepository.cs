using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationPageSectionLanguageRepository : IClassificationPageSectionLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationPageSectionLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuClassificationPageSectionLanguageModel AddClassificationPageSectionLanguage(SuClassificationPageSectionLanguageModel suClassificationPageSectionLanguage)
        {
            context.DbClassificationPageSectionLanguage.Add(suClassificationPageSectionLanguage);
            context.SaveChanges();
            return suClassificationPageSectionLanguage;
        }

        public SuClassificationPageSectionLanguageModel DeleteClassificationPageSectionLanguage(int Id)
        {
            var suClassificationPageSectionLanguage = context.DbClassificationPageSectionLanguage.Find(Id);
            if (suClassificationPageSectionLanguage != null)
            {
                context.DbClassificationPageSectionLanguage.Remove(suClassificationPageSectionLanguage);
                context.SaveChanges();

            }
            return suClassificationPageSectionLanguage;

        }

        public IEnumerable<SuClassificationPageSectionLanguageModel> GetAllClassificationPageSectionLanguages()
        {
            return context.DbClassificationPageSectionLanguage;//.AsNoTracking();
        }

        public SuClassificationPageSectionLanguageModel GetClassificationPageSectionLanguage(int Id)
        {
            return context.DbClassificationPageSectionLanguage.Find(Id);
        }

        public SuClassificationPageSectionLanguageModel UpdateClassificationPageSectionLanguage(SuClassificationPageSectionLanguageModel suClassificationPageSectionLanguageChanges)
        {
            var suClassificationPageSectionLanguage = context.DbClassificationPageSectionLanguage.Attach(suClassificationPageSectionLanguageChanges);
            suClassificationPageSectionLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationPageSectionLanguageChanges;
        }
    }
}
