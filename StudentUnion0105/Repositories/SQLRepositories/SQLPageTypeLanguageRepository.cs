using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageTypeLanguageRepository : IPageTypeLanguageRepository
    {
        private readonly SuDbContext Context;

        public SQLPageTypeLanguageRepository(SuDbContext context)
        {
            Context = context;
        }

        public SuPageTypeLanguageModel AddPageTypeLanguage(SuPageTypeLanguageModel suPageTypeLanguage)
        {
            Context.dbPageTypeLanguage.Add(suPageTypeLanguage);
            Context.SaveChanges();
            return suPageTypeLanguage;
        }

        public SuPageTypeLanguageModel DeletePageTypeLanguage(int Id)
        {
            var suPageTypeLanguage = Context.dbPageTypeLanguage.Find(Id);
            if (suPageTypeLanguage != null)
            {
                Context.dbPageTypeLanguage.Remove(suPageTypeLanguage);
                Context.SaveChanges();

            }
            return suPageTypeLanguage;
        }

        public IEnumerable<SuPageTypeLanguageModel> GetAllPageTypeLanguages()
        {
            return Context.dbPageTypeLanguage;
        }

        public SuPageTypeLanguageModel GetPageTypeLanguage(int Id)
        {
            return Context.dbPageTypeLanguage.Find(Id);
        }

        public SuPageTypeLanguageModel UpdatePageTypeLanguage(SuPageTypeLanguageModel suPageTypeLanguageChanges)
        {
            var changedPageTypeLanguage = Context.dbPageTypeLanguage.Attach(suPageTypeLanguageChanges);
            changedPageTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return suPageTypeLanguageChanges;
        }
    }
}
