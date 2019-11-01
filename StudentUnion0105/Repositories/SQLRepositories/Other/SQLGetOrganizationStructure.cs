using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Repositories;
using StudentUnion0105.SPModel;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLGetOrganizationStructure : IGetOrganizationStructureRepository
    {
        private readonly SuDbContext context;

        public SQLGetOrganizationStructure(SuDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SuOrganizationIndexGet> GetOrganizationStructure(int Id)
        {
            var a = context.ZdbOrganizationIndexGet.FromSql("OrgStructure {0}", Id);

            return a;
        }
    }
}
