using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLOrganizationStatusRepository : IOrganizationStatusRepository
    {
        private readonly SuDbContext context;

        public SQLOrganizationStatusRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuOrganizationStatusModel> GetAllOrganizationStatus()
        {
            return context.dbOrganizationStatus;
        }

        public SuOrganizationStatusModel GetSuOrganizationStatus(int Id)
        {
            return context.dbOrganizationStatus.Find(Id);
        }
    }
}
