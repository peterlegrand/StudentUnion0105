using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Repositories;
using StudentUnion0105.SPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLGetOrganizationStructure : IGetOrganizationStructureRepository
    {
        private readonly SuDbContext context;

        public SQLGetOrganizationStructure(SuDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SuGetOrganizationStructure> GetOrganizationStructure(int Id)
        {
            var a = context.dbGetOrganizationStructure.FromSql("OrgStructure {0}", Id);

            return a;
        }
    }
}
