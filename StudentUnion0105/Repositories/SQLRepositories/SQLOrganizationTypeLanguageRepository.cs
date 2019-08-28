using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLOrganizationTypeLanguageRepository : IOrganizationTypeLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLOrganizationTypeLanguageRepository(SuDbContext context)
        {
            Context = context;
        }

        public SuOrganizationTypeLanguageModel AddOrganizationTypeLanguage(SuOrganizationTypeLanguageModel suOrganizationTypeLanguage)
        {
            context.dbOrganizationTypeLanguage.Add(suOrganizationTypeLanguage);
            context.SaveChanges();
            return suOrganizationTypeLanguage;
        }

        public SuOrganizationTypeLanguageModel DeleteOrganizationTypeLanguage(int Id)
        {
            var suOrganizationTypeLanguage = context.dbOrganizationTypeLanguage.Find(Id);
            if (suOrganizationTypeLanguage != null)
            {
                context.dbOrganizationTypeLanguage.Remove(suOrganizationTypeLanguage);
                context.SaveChanges();

            }
            return suOrganizationTypeLanguage;
        }

        public IEnumerable<SuOrganizationTypeLanguageModel> GetAllOrganizationTypeLanguages()
        {
            return context.dbOrganizationTypeLanguage;
        }

        public SuOrganizationTypeLanguageModel GetOrganizationTypeLanguage(int Id)
        {
            return context.dbOrganizationTypeLanguage.Find(Id);
        }

        public SuOrganizationTypeLanguageModel UpdateOrganizationTypeLanguage(SuOrganizationTypeLanguageModel suOrganizationTypeLanguageChanges)
        {
            var changedOrganizationTypeLanguage = context.dbOrganizationTypeLanguage.Attach(suOrganizationTypeLanguageChanges);
            changedOrganizationTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suOrganizationTypeLanguageChanges;
        }
    }
}
