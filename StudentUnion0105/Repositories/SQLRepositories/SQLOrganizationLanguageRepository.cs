using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.dbOrganizationLanguage.Add(suOrganizationLanguage);
            context.SaveChanges();
            return suOrganizationLanguage;
        }

        public SuOrganizationLanguageModel DeleteOrganizationLanguage(int Id)
        {
            var suOrganizationLanguage = context.dbOrganizationLanguage.Find(Id);
            if (suOrganizationLanguage != null)
            {
                context.dbOrganizationLanguage.Remove(suOrganizationLanguage);
                context.SaveChanges();

            }
            return suOrganizationLanguage;
        }

        public IEnumerable<SuOrganizationLanguageModel> GetAllOrganizationLanguages()
        {
            return context.dbOrganizationLanguage;
        }

        public SuOrganizationLanguageModel GetOrganizationLanguage(int Id)
        {
            return context.dbOrganizationLanguage.Find(Id);
        }

        public SuOrganizationLanguageModel UpdateOrganizationLanguage(SuOrganizationLanguageModel suOrganizationLanguageChanges)
        {
            var suOrganizationLanguage = context.dbOrganizationLanguage.Attach(suOrganizationLanguageChanges);
            suOrganizationLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suOrganizationLanguageChanges;
        }
    }
}
