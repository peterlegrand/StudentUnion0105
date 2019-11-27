using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUserOrganizationTypeLanguageRepository : IUserOrganizationTypeLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLUserOrganizationTypeLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuUserOrganizationTypeLanguageModel AddUserOrganizationTypeLanguage(SuUserOrganizationTypeLanguageModel suUserOrganizationTypeLanguage)
        {
            context.DbUserOrganizationTypeLanguage.Add(suUserOrganizationTypeLanguage);
            context.SaveChanges();
            return suUserOrganizationTypeLanguage;
        }

        public SuUserOrganizationTypeLanguageModel DeleteUserOrganizationTypeLanguage(int Id)
        {
            var suUserOrganizationTypeLanguage = context.DbUserOrganizationTypeLanguage.Find(Id);
            if (suUserOrganizationTypeLanguage != null)
            {
                context.DbUserOrganizationTypeLanguage.Remove(suUserOrganizationTypeLanguage);
                context.SaveChanges();

            }
            return suUserOrganizationTypeLanguage;
        }

        public IEnumerable<SuUserOrganizationTypeLanguageModel> GetAllUserOrganizationTypeLanguages()
        {
            return context.DbUserOrganizationTypeLanguage;
        }

        public SuUserOrganizationTypeLanguageModel GetUserOrganizationTypeLanguage(int Id)
        {
            return context.DbUserOrganizationTypeLanguage.Find(Id);
        }

        public SuUserOrganizationTypeLanguageModel UpdateUserOrganizationTypeLanguage(SuUserOrganizationTypeLanguageModel suUserOrganizationTypeLanguageChanges)
        {
            var suUserOrganizationTypeLanguage = context.DbUserOrganizationTypeLanguage.Attach(suUserOrganizationTypeLanguageChanges);
            suUserOrganizationTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserOrganizationTypeLanguageChanges;
        }
    }
}
