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
            context.dbUserRelationTypeLanguage.Add(suUserRelationTypeLanguage);
            context.SaveChanges();
            return suUserRelationTypeLanguage;
        }

        public SuUserRelationTypeLanguageModel DeleteUserRelationTypeLanguage(int Id)
        {
            var suUserRelationTypeLanguage = context.dbUserRelationTypeLanguage.Find(Id);
            if (suUserRelationTypeLanguage != null)
            {
                context.dbUserRelationTypeLanguage.Remove(suUserRelationTypeLanguage);
                context.SaveChanges();

            }
            return suUserRelationTypeLanguage;
        }

        public IEnumerable<SuUserRelationTypeLanguageModel> GetAllUserRelationTypeLanguages()
        {
            return context.dbUserRelationTypeLanguage;
        }

        public SuUserRelationTypeLanguageModel GetUserRelationTypeLanguage(int Id)
        {
            return context.dbUserRelationTypeLanguage.Find(Id);
        }

        public SuUserRelationTypeLanguageModel UpdateUserRelationTypeLanguage(SuUserRelationTypeLanguageModel suUserRelationTypeLanguageChanges)
        {
            var suUserRelationTypeLanguage = context.dbUserRelationTypeLanguage.Attach(suUserRelationTypeLanguageChanges);
            suUserRelationTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserRelationTypeLanguageChanges;
        }
    }
}
