using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLObjectLanguageEditRepository : IObjectLanguageEditRepository
    {
        private readonly SuDbContext context;

        public SQLObjectLanguageEditRepository(SuDbContext context)
        {
            this.context = context;
            //  this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public SuObjectLanguageEditGet GetObject(int ID)
        {
            return context.dbObjectLanguage.Find(ID);
        }

    }
}
