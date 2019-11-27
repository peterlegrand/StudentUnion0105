using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLOrganizationLanguageRepository : IOrganizationLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLOrganizationLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuOrganizationLanguageModel AddOrganizationLanguage(SuOrganizationLanguageModel suOrganizationLanguage)
        {
            context.DbOrganizationLanguage.Add(suOrganizationLanguage);
            context.SaveChanges();
            return suOrganizationLanguage;
        }

        public SuOrganizationLanguageModel DeleteOrganizationLanguage(int Id)
        {
            var suOrganizationLanguage = context.DbOrganizationLanguage.Find(Id);
            if (suOrganizationLanguage != null)
            {
                context.DbOrganizationLanguage.Remove(suOrganizationLanguage);
                context.SaveChanges();

            }
            return suOrganizationLanguage;
        }

        public IEnumerable<SuOrganizationLanguageModel> GetAllOrganizationLanguages()
        {
            return context.DbOrganizationLanguage;
        }

        public SuOrganizationLanguageModel GetOrganizationLanguage(int Id)
        {
            return context.DbOrganizationLanguage.Find(Id);
        }

        public SuOrganizationLanguageModel UpdateOrganizationLanguage(SuOrganizationLanguageModel suOrganizationLanguageChanges)
        {
            var suOrganizationLanguage = context.DbOrganizationLanguage.Attach(suOrganizationLanguageChanges);
            suOrganizationLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suOrganizationLanguageChanges;
        }
    }
}
