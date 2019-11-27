using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProjectLanguageRepository : IProjectLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProjectLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProjectLanguageModel AddProjectLanguage(SuProjectLanguageModel suProjectLanguage)
        {
            context.DbProjectLanguage.Add(suProjectLanguage);
            context.SaveChanges();
            return suProjectLanguage;
        }

        public SuProjectLanguageModel DeleteProjectLanguage(int Id)
        {
            var suProjectLanguage = context.DbProjectLanguage.Find(Id);
            if (suProjectLanguage != null)
            {
                context.DbProjectLanguage.Remove(suProjectLanguage);
                context.SaveChanges();
            }
            return suProjectLanguage;

        }

        public IEnumerable<SuProjectLanguageModel> GetAllProjectLanguages()
        {
            return context.DbProjectLanguage;
        }

        public SuProjectLanguageModel GetProjectLanguage(int Id)
        {
            return context.DbProjectLanguage.Find(Id);
        }

        public SuProjectLanguageModel UpdateProjectLanguage(SuProjectLanguageModel suProjectLanguageChanges)
        {
            var changedProjectLanguage = context.DbProjectLanguage.Attach(suProjectLanguageChanges);
            changedProjectLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProjectLanguageChanges;

        }
    }
}
