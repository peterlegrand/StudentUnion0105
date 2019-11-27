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
            context.DbUserProjectTypeLanguage.Add(suUserProjectTypeLanguage);
            context.SaveChanges();
            return suUserProjectTypeLanguage;
        }

        public SuUserProjectTypeLanguageModel DeleteUserProjectTypeLanguage(int Id)
        {
            var suUserProjectTypeLanguage = context.DbUserProjectTypeLanguage.Find(Id);
            if (suUserProjectTypeLanguage != null)
            {
                context.DbUserProjectTypeLanguage.Remove(suUserProjectTypeLanguage);
                context.SaveChanges();

            }
            return suUserProjectTypeLanguage;
        }

        public IEnumerable<SuUserProjectTypeLanguageModel> GetAllUserProjectTypeLanguages()
        {
            return context.DbUserProjectTypeLanguage;
        }

        public SuUserProjectTypeLanguageModel GetUserProjectTypeLanguage(int Id)
        {
            return context.DbUserProjectTypeLanguage.Find(Id);
        }

        public SuUserProjectTypeLanguageModel UpdateUserProjectTypeLanguage(SuUserProjectTypeLanguageModel suUserProjectTypeLanguageChanges)
        {
            var suUserProjectTypeLanguage = context.DbUserProjectTypeLanguage.Attach(suUserProjectTypeLanguageChanges);
            suUserProjectTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserProjectTypeLanguageChanges;
        }
    }
}
