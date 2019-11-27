using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFlowConditionLanguageRepository : IProcessTemplateFlowConditionLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFlowConditionLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFlowConditionLanguageModel AddProcessTemplateFlowConditionLanguage(SuProcessTemplateFlowConditionLanguageModel suProcessTemplateFlowConditionLanguage)
        {
            context.DbProcessTemplateFlowConditionLanguage.Add(suProcessTemplateFlowConditionLanguage);
            context.SaveChanges();
            return suProcessTemplateFlowConditionLanguage;
        }

        public SuProcessTemplateFlowConditionLanguageModel DeleteProcessTemplateFlowConditionLanguage(int Id)
        {
            var suProcessTemplateFlowConditionLanguage = context.DbProcessTemplateFlowConditionLanguage.Find(Id);
            if (suProcessTemplateFlowConditionLanguage != null)
            {
                context.DbProcessTemplateFlowConditionLanguage.Remove(suProcessTemplateFlowConditionLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateFlowConditionLanguage;
        }

        public IEnumerable<SuProcessTemplateFlowConditionLanguageModel> GetAllProcessTemplateFlowConditionLanguages()
        {
            return context.DbProcessTemplateFlowConditionLanguage;

        }

        public SuProcessTemplateFlowConditionLanguageModel GetProcessTemplateFlowConditionLanguage(int Id)
        {
            return context.DbProcessTemplateFlowConditionLanguage.Find(Id);
        }

        public SuProcessTemplateFlowConditionLanguageModel UpdateProcessTemplateFlowConditionLanguage(SuProcessTemplateFlowConditionLanguageModel suProcessTemplateFlowConditionLanguageChanges)
        {
            var changedProcessTemplateFlowConditionLanguage = context.DbProcessTemplateFlowConditionLanguage.Attach(suProcessTemplateFlowConditionLanguageChanges);
            changedProcessTemplateFlowConditionLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFlowConditionLanguageChanges;

        }
    }
}
