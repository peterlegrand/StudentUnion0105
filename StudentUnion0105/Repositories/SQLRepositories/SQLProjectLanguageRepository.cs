using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.dbProjectLanguage.Add(suProjectLanguage);
            context.SaveChanges();
            return suProjectLanguage;
        }

        public SuProjectLanguageModel DeleteProjectLanguage(int Id)
        {
            var suProjectLanguage = context.dbProjectLanguage.Find(Id);
            if (suProjectLanguage != null)
            {
                context.dbProjectLanguage.Remove(suProjectLanguage);
                context.SaveChanges();
            }
            return suProjectLanguage;

        }

        public IEnumerable<SuProjectLanguageModel> GetAllProjectLanguages()
        {
            return context.dbProjectLanguage;
        }

        public SuProjectLanguageModel GetProjectLanguage(int Id)
        {
            return context.dbProjectLanguage.Find(Id);
        }

        public SuProjectLanguageModel UpdateProjectLanguage(SuProjectLanguageModel suProjectLanguageChanges)
        {
            var changedProjectLanguage = context.dbProjectLanguage.Attach(suProjectLanguageChanges);
            changedProjectLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProjectLanguageChanges;

        }
    }
}
