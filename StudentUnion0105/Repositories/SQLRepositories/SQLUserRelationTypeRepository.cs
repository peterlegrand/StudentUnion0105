using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUserRelationTypeRepository : IUserRelationTypeRepository
    {
        private readonly SuDbContext context;

        public SQLUserRelationTypeRepository(SuDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SuUserRelationTypeModel> GetAllUserRelationTypes()
        {
            return context.dbUserRelationType;
        }

        public SuUserRelationTypeModel GetUserRelationType(int Id)
        {
            return context.dbUserRelationType.Find(Id);
        }

    }
}
