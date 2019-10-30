using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageLanguageEditGetRepository : IPageLanguageEditGetRepository
    {
        private readonly SuDbContext context;

        public SQLPageLanguageEditGetRepository(SuDbContext context)
        {
            this.context = context;
            //  this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public SuPageLanguageEditGetModel GetPageLanguageEditGet(int ID)
        {

            return context.ZdbPageLanguageEditGet.Find(ID);
        }

    }
}
