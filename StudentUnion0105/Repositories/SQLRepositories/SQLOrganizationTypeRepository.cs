using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.dbOrganizationType.Add(suOrganizationType);
            context.SaveChanges();
            return suOrganizationType;
        }

        public SuOrganizationTypeModel DeleteOrganizationType(int Id)
        {
            var suOrganizationType = context.dbOrganizationType.Find(Id);
            if (suOrganizationType != null)
            {
                context.dbOrganizationType.Remove(suOrganizationType);
                context.SaveChanges();

            }
            return suOrganizationType;
        }

        public IEnumerable<SuOrganizationTypeModel> GetAllOrganizationTypes()
        {
            return context.dbOrganizationType;
        }

        public SuOrganizationTypeModel GetOrganizationType(int Id)
        {
            return context.dbOrganizationType.Find(Id);
        }

        public SuOrganizationTypeModel UpdateOrganizationType(SuOrganizationTypeModel suOrganizationTypeChanges)
        {
            var changedOrganizationType = context.dbOrganizationType.Attach(suOrganizationTypeChanges);
            changedOrganizationType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suOrganizationTypeChanges;

        }
    }
}
