using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;
namespace StudentUnion0105.SQLRepositories
{
    public class SQLUserProjectTypeLanguageRepository : IUserProjectTypeLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLUserProjectTypeLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuUserProjectTypeLanguageModel AddUserProjectTypeLanguage(SuUserProjectTypeLanguageModel suUserProjectTypeLanguage)
        {
            context.dbUserProjectTypeLanguage.Add(suUserProjectTypeLanguage);
            context.SaveChanges();
            return suUserProjectTypeLanguage;
        }

        public SuUserProjectTypeLanguageModel DeleteUserProjectTypeLanguage(int Id)
        {
            var suUserProjectTypeLanguage = context.dbUserProjectTypeLanguage.Find(Id);
            if (suUserProjectTypeLanguage != null)
            {
                context.dbUserProjectTypeLanguage.Remove(suUserProjectTypeLanguage);
                context.SaveChanges();

            }
            return suUserProjectTypeLanguage;
        }

        public IEnumerable<SuUserProjectTypeLanguageModel> GetAllUserProjectTypeLanguages()
        {
            return context.dbUserProjectTypeLanguage;
        }

        public SuUserProjectTypeLanguageModel GetUserProjectTypeLanguage(int Id)
        {
            return context.dbUserProjectTypeLanguage.Find(Id);
        }

        public SuUserProjectTypeLanguageModel UpdateUserProjectTypeLanguage(SuUserProjectTypeLanguageModel suUserProjectTypeLanguageChanges)
        {
            var suUserProjectTypeLanguage = context.dbUserProjectTypeLanguage.Attach(suUserProjectTypeLanguageChanges);
            suUserProjectTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserProjectTypeLanguageChanges;
        }
    }
}
