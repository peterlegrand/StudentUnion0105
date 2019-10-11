using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUserOrganizationRepository : IUserOrganizationRepository
    {
        private readonly SuDbContext context;

        public SQLUserOrganizationRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuUserOrganizationModel AddUserOrganization(SuUserOrganizationModel suUserOrganization)
        {
            context.dbUserOrganization.Add(suUserOrganization);
            context.SaveChanges();
            return suUserOrganization;
        }

        public SuUserOrganizationModel DeleteUserOrganization(int Id)
        {
            var suUserOrganization = context.dbUserOrganization.Find(Id);
            if (suUserOrganization != null)
            {
                context.dbUserOrganization.Remove(suUserOrganization);
                context.SaveChanges();

            }
            return suUserOrganization;
        }

        public IEnumerable<SuUserOrganizationModel> GetAllUserOrganizations()
        {
            return context.dbUserOrganization;
        }

        public SuUserOrganizationModel GetUserOrganization(int Id)
        {
            return context.dbUserOrganization.Find(Id);
        }

        public SuUserOrganizationModel UpdateUserOrganization(SuUserOrganizationModel suUserOrganizationChanges)
        {
            var suUserOrganization = context.dbUserOrganization.Attach(suUserOrganizationChanges);
            suUserOrganization.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserOrganizationChanges;
        }
    }
}
