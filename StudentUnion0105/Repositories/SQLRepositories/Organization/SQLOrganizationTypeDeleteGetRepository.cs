using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLOrganizationTypeDeleteGetRepository : IOrganizationTypeDeleteGetRepository
    {
        private readonly SuDbContext context;

        public SQLOrganizationTypeDeleteGetRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuOrganizationTypeDeleteGetModel GetOrganizationType(int Id)
        {
            return context.ZDbOrganizationTypeDeleteGet.Find(Id);
        }
    }
}
