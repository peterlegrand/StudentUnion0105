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
            context.dbPageLanguage.Add(suPageLanguage);
            context.SaveChanges();
            return suPageLanguage;
        }

        public SuPageLanguageModel DeletePageLanguage(int Id)
        {
            var suPageLanguage = context.dbPageLanguage.Find(Id);
            if (suPageLanguage != null)
            {
                context.dbPageLanguage.Remove(suPageLanguage);
                context.SaveChanges();

            }
            return suPageLanguage;
        }

        public IEnumerable<SuPageLanguageModel> GetAllPageLanguages()
        {
            return context.dbPageLanguage;
        }

        public SuPageLanguageModel GetPageLanguage(int Id)
        {
            return context.dbPageLanguage.Find(Id);
        }

        public SuPageLanguageModel UpdatePageLanguage(SuPageLanguageModel suPageLanguageChanges)
        {
            var suPageLanguage = context.dbPageLanguage.Attach(suPageLanguageChanges);
            suPageLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageLanguageChanges;
        }
    }
}
