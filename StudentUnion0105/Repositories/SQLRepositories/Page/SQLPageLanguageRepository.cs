using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageLanguageRepository : IPageLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLPageLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuPageLanguageModel AddPageLanguage(SuPageLanguageModel suPageLanguage)
        {
            context.DbPageLanguage.Add(suPageLanguage);
            context.SaveChanges();
            return suPageLanguage;
        }

        public SuPageLanguageModel DeletePageLanguage(int Id)
        {
            var suPageLanguage = context.DbPageLanguage.Find(Id);
            if (suPageLanguage != null)
            {
                context.DbPageLanguage.Remove(suPageLanguage);
                context.SaveChanges();

            }
            return suPageLanguage;
        }

        public IEnumerable<SuPageLanguageModel> GetAllPageLanguages()
        {
            return context.DbPageLanguage;
        }

        public SuPageLanguageModel GetPageLanguage(int Id)
        {
            return context.DbPageLanguage.Find(Id);
        }

        public SuPageLanguageModel UpdatePageLanguage(SuPageLanguageModel suPageLanguageChanges)
        {
            var suPageLanguage = context.DbPageLanguage.Attach(suPageLanguageChanges);
            suPageLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageLanguageChanges;
        }
    }
}
