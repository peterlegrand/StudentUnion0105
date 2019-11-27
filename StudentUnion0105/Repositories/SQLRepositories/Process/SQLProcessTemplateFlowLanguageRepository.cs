using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFlowLanguageRepository : IProcessTemplateFlowLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFlowLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFlowLanguageModel AddProcessTemplateFlowLanguage(SuProcessTemplateFlowLanguageModel suProcessTemplateFlowLanguage)
        {
            context.DbProcessTemplateFlowLanguage.Add(suProcessTemplateFlowLanguage);
            context.SaveChanges();
            return suProcessTemplateFlowLanguage;
        }

        public SuProcessTemplateFlowLanguageModel DeleteProcessTemplateFlowLanguage(int Id)
        {
            var suProcessTemplateFlowLanguage = context.DbProcessTemplateFlowLanguage.Find(Id);
            if (suProcessTemplateFlowLanguage != null)
            {
                context.DbProcessTemplateFlowLanguage.Remove(suProcessTemplateFlowLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateFlowLanguage;
        }

        public IEnumerable<SuProcessTemplateFlowLanguageModel> GetAllProcessTemplateFlowLanguages()
        {
            return context.DbProcessTemplateFlowLanguage;

        }

        public SuProcessTemplateFlowLanguageModel GetProcessTemplateFlowLanguage(int Id)
        {
            return context.DbProcessTemplateFlowLanguage.Find(Id);
        }

        public SuProcessTemplateFlowLanguageModel UpdateProcessTemplateFlowLanguage(SuProcessTemplateFlowLanguageModel suProcessTemplateFlowLanguageChanges)
        {
            var changedProcessTemplateFlowLanguage = context.DbProcessTemplateFlowLanguage.Attach(suProcessTemplateFlowLanguageChanges);
            changedProcessTemplateFlowLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFlowLanguageChanges;

        }
    }
}
