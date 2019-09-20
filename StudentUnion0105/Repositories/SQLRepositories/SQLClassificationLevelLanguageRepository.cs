using StudentUnion0105.Data;
using System;
using StudentUnion0105.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentUnion0105.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationLevelLanguageRepository : IClassificationLevelLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationLevelLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuClassificationLevelLanguageModel AddClassificationLevelLanguage(SuClassificationLevelLanguageModel suClassificationLevelLanguage)
        {
            context.dbClassificationLevelLanguage.Add(suClassificationLevelLanguage);
            context.SaveChanges();
            return suClassificationLevelLanguage;
        }

        public SuClassificationLevelLanguageModel DeleteClassificationLevelLanguage(int Id)
        {
            var suClassificationLevelLanguage = context.dbClassificationLevelLanguage.Find(Id);
            if (suClassificationLevelLanguage != null)
            {
                context.dbClassificationLevelLanguage.Remove(suClassificationLevelLanguage);
                context.SaveChanges();

            }
            return suClassificationLevelLanguage;

        }

        public IEnumerable<SuClassificationLevelLanguageModel> GetAllClassificationLevelLanguages()
        {
            return context.dbClassificationLevelLanguage;//.AsNoTracking();
        }

        public SuClassificationLevelLanguageModel GetClassificationLevelLanguage(int Id)
        {
            return context.dbClassificationLevelLanguage.Find(Id);
        }

        public SuClassificationLevelLanguageModel UpdateClassificationLevelLanguage(SuClassificationLevelLanguageModel suClassificationLevelLanguageChanges)
        {
            var suClassificationLevelLanguage = context.dbClassificationLevelLanguage.Attach(suClassificationLevelLanguageChanges);
            suClassificationLevelLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationLevelLanguageChanges;
        }
    }
}
