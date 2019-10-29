using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLObjectLanguageEditGetRepository : IObjectLanguageEditGetRepository
    {
        private readonly SuDbContext context;

        public SQLObjectLanguageEditGetRepository(SuDbContext context)
        {
            this.context = context;
            //  this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public SuObjectLanguageEditGetModel GetObjectLanguageEditGet(int ID)
        {

            return context.ZdbObjectLanguageEditGet.Find(ID);
        }

    }
}
