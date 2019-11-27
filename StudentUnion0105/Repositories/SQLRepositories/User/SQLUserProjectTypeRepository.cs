using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUserProjectTypeRepository : IUserProjectTypeRepository
    {
        private readonly SuDbContext context;

        public SQLUserProjectTypeRepository(SuDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SuUserProjectTypeModel> GetAllUserProjectTypes()
        {
            return context.DbUserProjectType;
        }

        public SuUserProjectTypeModel GetUserProjectType(int Id)
        {
            return context.DbUserProjectType.Find(Id);
        }

    }
}
