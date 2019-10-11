using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLCountryRepository : ICountryRepository
    {
        private readonly SuDbContext context;

        public SQLCountryRepository(SuDbContext context)
        {
            this.context = context;
            //  this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IEnumerable<SuCountryModel> GetAllCountrys()
        {
            return context.dbCountry;


        }

        public SuCountryModel GetCountry(int ID)
        {
            return context.dbCountry.Find(ID);
        }

    }
}
