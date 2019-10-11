using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Repositories;
using System.Collections.Generic;
using static StudentUnion0105.SPModel.GetProjectStructure;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLGetProjectStructure : IGetProjectStructureRepository
    {
        private readonly SuDbContext context;

        public SQLGetProjectStructure(SuDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SuGetProjectStructure> GetProjectStructure(int Id)
        {
            var a = context.dbGetProjectStructure.FromSql("ProjStructure {0}", Id);

            return a;
        }
    }
}

