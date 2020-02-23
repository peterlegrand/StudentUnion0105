using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLOrganizationDeleteGetRepository : IOrganizationDeleteGetRepository
    {
        private readonly SuDbContext context;

        public SQLOrganizationDeleteGetRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuOrganizationDeleteGetModel GetOrganization(int Id)
        {
            return context.ZDbOrganizationDeleteGet.Find(Id);
        }
    }
}
