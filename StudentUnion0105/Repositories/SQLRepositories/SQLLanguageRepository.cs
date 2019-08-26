using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLLanguageRepository : ILanguageRepository
    {
        private readonly SuDbContext context;

        public SQLLanguageRepository(SuDbContext context)
        {
            this.context = context;
          //  this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IEnumerable<SuLanguageModel> GetAllLanguages()
        {
            return context.dbLanguage;
          

        }

        public SuLanguageModel GetSuLanguage(int ID)
        {
            return context.dbLanguage.Find(ID);
        }

        public SuLanguageModel UpdateLanguage(SuLanguageModel suLanguageChanges)
        {
            var suLanguage = context.dbLanguage.Attach(suLanguageChanges);
            suLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suLanguageChanges;
        }
    }
}
