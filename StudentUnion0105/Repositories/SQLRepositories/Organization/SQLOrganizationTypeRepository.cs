using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLOrganizationTypeRepository : IOrganizationTypeRepository
    {
        private readonly SuDbContext context;

        public SQLOrganizationTypeRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuOrganizationTypeModel AddOrganizationType(SuOrganizationTypeModel suOrganizationType)
        {
            context.DbOrganizationType.Add(suOrganizationType);
            context.SaveChanges();
            return suOrganizationType;
        }

        public SuOrganizationTypeModel DeleteOrganizationType(int Id)
        {
            var suOrganizationType = context.DbOrganizationType.Find(Id);
            if (suOrganizationType != null)
            {
                context.DbOrganizationType.Remove(suOrganizationType);
                context.SaveChanges();

            }
            return suOrganizationType;
        }

        public IEnumerable<SuOrganizationTypeModel> GetAllOrganizationTypes()
        {
            return context.DbOrganizationType;
        }

        public SuOrganizationTypeModel GetOrganizationType(int Id)
        {
            return context.DbOrganizationType.Find(Id);
        }

        public SuOrganizationTypeModel UpdateOrganizationType(SuOrganizationTypeModel suOrganizationTypeChanges)
        {
            var changedOrganizationType = context.DbOrganizationType.Attach(suOrganizationTypeChanges);
            changedOrganizationType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suOrganizationTypeChanges;

        }
    }
}
