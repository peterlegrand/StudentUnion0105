using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUserRelationTypeLanguageRepository : IUserRelationTypeLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLUserRelationTypeLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuUserRelationTypeLanguageModel AddUserRelationTypeLanguage(SuUserRelationTypeLanguageModel suUserRelationTypeLanguage)
        {
            context.DbUserRelationTypeLanguage.Add(suUserRelationTypeLanguage);
            context.SaveChanges();
            return suUserRelationTypeLanguage;
        }

        public SuUserRelationTypeLanguageModel DeleteUserRelationTypeLanguage(int Id)
        {
            var suUserRelationTypeLanguage = context.DbUserRelationTypeLanguage.Find(Id);
            if (suUserRelationTypeLanguage != null)
            {
                context.DbUserRelationTypeLanguage.Remove(suUserRelationTypeLanguage);
                context.SaveChanges();

            }
            return suUserRelationTypeLanguage;
        }

        public IEnumerable<SuUserRelationTypeLanguageModel> GetAllUserRelationTypeLanguages()
        {
            return context.DbUserRelationTypeLanguage;
        }

        public SuUserRelationTypeLanguageModel GetUserRelationTypeLanguage(int Id)
        {
            return context.DbUserRelationTypeLanguage.Find(Id);
        }

        public SuUserRelationTypeLanguageModel UpdateUserRelationTypeLanguage(SuUserRelationTypeLanguageModel suUserRelationTypeLanguageChanges)
        {
            var suUserRelationTypeLanguage = context.DbUserRelationTypeLanguage.Attach(suUserRelationTypeLanguageChanges);
            suUserRelationTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserRelationTypeLanguageChanges;
        }
    }
}
