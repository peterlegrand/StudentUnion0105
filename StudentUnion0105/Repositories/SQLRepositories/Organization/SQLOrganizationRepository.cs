using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLOrganizationRepository : IOrganizationRepository
    {
        private readonly SuDbContext context;

        public SQLOrganizationRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuOrganizationModel AddOrganization(SuOrganizationModel suOrganization)
        {
            context.DbOrganization.Add(suOrganization);
            context.SaveChanges();
            return suOrganization;
        }

        public SuOrganizationModel DeleteOrganization(int Id)
        {
            var suOrganization = context.DbOrganization.Find(Id);
            if (suOrganization != null)
            {
                context.DbOrganization.Remove(suOrganization);
                context.SaveChanges();

            }
            return suOrganization;
        }

        public IEnumerable<SuOrganizationModel> GetAllOrganizations()
        {
            return context.DbOrganization;
        }

        public SuOrganizationModel GetOrganization(int Id)
        {
            return context.DbOrganization.Find(Id);
        }

        public SuOrganizationModel UpdateOrganization(SuOrganizationModel suOrganizationChanges)
        {
            var changedOrganization = context.DbOrganization.Attach(suOrganizationChanges);
            changedOrganization.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suOrganizationChanges;

        }
    }
}
