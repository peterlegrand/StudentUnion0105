using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.dbClassificationValueLanguage.Add(suClassificationValueLanguage);
            context.SaveChanges();
            return suClassificationValueLanguage;
        }

        public SuClassificationValueLanguageModel DeleteClassificationValueLanguage(int Id)
        {
            var suClassificationValueLanguage = context.dbClassificationValueLanguage.Find(Id);
            if (suClassificationValueLanguage != null)
            {
                context.dbClassificationValueLanguage.Remove(suClassificationValueLanguage);
                context.SaveChanges();

            }
            return suClassificationValueLanguage;
        }


        public IEnumerable<SuClassificationValueLanguageModel> GetAllClassificationValueLanguages()
        {
            return context.dbClassificationValueLanguage;
        }

        public SuClassificationValueLanguageModel GetClassificationValueLanguage(int Id)
        {
            return context.dbClassificationValueLanguage.Find(Id);
        }

        public SuClassificationValueLanguageModel UpdateClassificationValueLanguage(SuClassificationValueLanguageModel suClassificationValueLanguageChanges)
        {
            var changedClassificationValueLanguage = context.dbClassificationValueLanguage.Attach(suClassificationValueLanguageChanges);
            changedClassificationValueLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationValueLanguageChanges;

        }

    }
}
