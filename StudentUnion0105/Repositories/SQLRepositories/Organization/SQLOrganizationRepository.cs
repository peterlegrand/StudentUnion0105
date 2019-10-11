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
            context.dbOrganization.Add(suOrganization);
            context.SaveChanges();
            return suOrganization;
        }

        public SuOrganizationModel DeleteOrganization(int Id)
        {
            var suOrganization = context.dbOrganization.Find(Id);
            if (suOrganization != null)
            {
                context.dbOrganization.Remove(suOrganization);
                context.SaveChanges();

            }
            return suOrganization;
        }

        public IEnumerable<SuOrganizationModel> GetAllOrganizations()
        {
            return context.dbOrganization;
        }

        public SuOrganizationModel GetOrganization(int Id)
        {
            return context.dbOrganization.Find(Id);
        }

        public SuOrganizationModel UpdateOrganization(SuOrganizationModel suOrganizationChanges)
        {
            var changedOrganization = context.dbOrganization.Attach(suOrganizationChanges);
            changedOrganization.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suOrganizationChanges;

        }
    }
}
