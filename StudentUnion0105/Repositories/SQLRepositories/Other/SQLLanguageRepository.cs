using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

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
            return context.DbLanguage;


        }

        public SuLanguageModel GetLanguage(int ID)
        {
            return context.DbLanguage.Find(ID);
        }

        public SuLanguageModel UpdateLanguage(SuLanguageModel suLanguageChanges)
        {
            var suLanguage = context.DbLanguage.Attach(suLanguageChanges);
            suLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suLanguageChanges;
        }
    }
}
