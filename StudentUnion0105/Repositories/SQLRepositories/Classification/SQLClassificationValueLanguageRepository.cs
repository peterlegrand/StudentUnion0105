using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationValueLanguageRepository : IClassificationValueLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationValueLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuClassificationValueLanguageModel AddClassificationValueLanguage(SuClassificationValueLanguageModel suClassificationValueLanguage)
        {
            context.DbClassificationValueLanguage.Add(suClassificationValueLanguage);
            context.SaveChanges();
            return suClassificationValueLanguage;
        }

        public SuClassificationValueLanguageModel DeleteClassificationValueLanguage(int Id)
        {
            var suClassificationValueLanguage = context.DbClassificationValueLanguage.Find(Id);
            if (suClassificationValueLanguage != null)
            {
                context.DbClassificationValueLanguage.Remove(suClassificationValueLanguage);
                context.SaveChanges();

            }
            return suClassificationValueLanguage;
        }


        public IEnumerable<SuClassificationValueLanguageModel> GetAllClassificationValueLanguages()
        {
            return context.DbClassificationValueLanguage;
        }

        public SuClassificationValueLanguageModel GetClassificationValueLanguage(int Id)
        {
            return context.DbClassificationValueLanguage.Find(Id);
        }

        public SuClassificationValueLanguageModel UpdateClassificationValueLanguage(SuClassificationValueLanguageModel suClassificationValueLanguageChanges)
        {
            var changedClassificationValueLanguage = context.DbClassificationValueLanguage.Attach(suClassificationValueLanguageChanges);
            changedClassificationValueLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationValueLanguageChanges;

        }

    }
}
