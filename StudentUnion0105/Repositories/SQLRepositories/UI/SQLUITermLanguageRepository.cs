using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUITermLanguageRepository : IUITermLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLUITermLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
            
        public IEnumerable<SuUITermLanguageModel> GetAllTermLanguages()
        {
            return context.DbUITermLanguage;
        }

        public SuUITermLanguageModel GetTermLanguage(int Id)
        {
            return context.DbUITermLanguage.Find(Id);
        }
        public SuUITermLanguageModel DeleteTermLanguage(int Id)
        {
            var SuUITermLanguage = context.DbUITermLanguage.Find(Id);
            if (SuUITermLanguage != null)
            {
                context.DbUITermLanguage.Remove(SuUITermLanguage);
                context.SaveChanges();
            }
            return SuUITermLanguage;
        }
        public SuUITermLanguageModel UpdateTermLanguage(SuUITermLanguageModel SuTermLanguageChanges)
        {
            var changedUITermLanguage = context.DbUITermLanguage.Attach(SuTermLanguageChanges);
            changedUITermLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return SuTermLanguageChanges;
        }
        public SuUITermLanguageModel AddTermLanguage(SuUITermLanguageModel SuTermLanguage)
        {
            context.DbUITermLanguage.Add(SuTermLanguage);
            context.SaveChanges();
            return SuTermLanguage;
        }



    }
}
