using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLOrganizationTypeLanguageRepository : IOrganizationTypeLanguageRepository
    {
        private readonly SuDbContext Context;

        public SQLOrganizationTypeLanguageRepository(SuDbContext context)
        {
            Context = context;
        }

        public SuOrganizationTypeLanguageModel AddOrganizationTypeLanguage(SuOrganizationTypeLanguageModel suOrganizationTypeLanguage)
        {
            Context.DbOrganizationTypeLanguage.Add(suOrganizationTypeLanguage);
            Context.SaveChanges();
            return suOrganizationTypeLanguage;
        }

        public SuOrganizationTypeLanguageModel DeleteOrganizationTypeLanguage(int Id)
        {
            var suOrganizationTypeLanguage = Context.DbOrganizationTypeLanguage.Find(Id);
            if (suOrganizationTypeLanguage != null)
            {
                Context.DbOrganizationTypeLanguage.Remove(suOrganizationTypeLanguage);
                Context.SaveChanges();

            }
            return suOrganizationTypeLanguage;
        }

        public IEnumerable<SuOrganizationTypeLanguageModel> GetAllOrganizationTypeLanguages()
        {
            return Context.DbOrganizationTypeLanguage;
        }

        public SuOrganizationTypeLanguageModel GetOrganizationTypeLanguage(int Id)
        {
            return Context.DbOrganizationTypeLanguage.Find(Id);
        }

        public SuOrganizationTypeLanguageModel UpdateOrganizationTypeLanguage(SuOrganizationTypeLanguageModel suOrganizationTypeLanguageChanges)
        {
            var changedOrganizationTypeLanguage = Context.DbOrganizationTypeLanguage.Attach(suOrganizationTypeLanguageChanges);
            changedOrganizationTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return suOrganizationTypeLanguageChanges;
        }
    }
}
