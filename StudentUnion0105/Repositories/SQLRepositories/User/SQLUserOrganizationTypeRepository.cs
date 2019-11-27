using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUserOrganizationTypeRepository : IUserOrganizationTypeRepository
    {
        private readonly SuDbContext context;

        public SQLUserOrganizationTypeRepository(SuDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SuUserOrganizationTypeModel> GetAllUserOrganizationTypes()
        {
            return context.DbUserOrganizationType;
        }

        public SuUserOrganizationTypeModel GetUserOrganizationType(int Id)
        {
            return context.DbUserOrganizationType.Find(Id);
        }

    }
}
