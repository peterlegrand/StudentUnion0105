using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLObjectLanguageIndexGetRepository : IObjectLanguageIndexGetRepository
    {
        private readonly SuDbContext context;

        public SQLObjectLanguageIndexGetRepository(SuDbContext context)
        {
            this.context = context;
            //  this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public SuObjectLanguageIndexGetModel GetObjectLanguageIndexGet(int ID)
        {
            return context.ZdbObjectLanguageIndexGet.Find(ID);
        }

    }
}
