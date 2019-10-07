using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFlowConditionTypeLanguageRepository : IProcessTemplateFlowConditionTypeLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFlowConditionTypeLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFlowConditionTypeLanguageModel AddProcessTemplateFlowConditionTypeLanguage(SuProcessTemplateFlowConditionTypeLanguageModel suProcessTemplateFlowConditionTypeLanguage)
        {
            context.dbProcessTemplateFlowConditionTypeLanguage.Add(suProcessTemplateFlowConditionTypeLanguage);
            context.SaveChanges();
            return suProcessTemplateFlowConditionTypeLanguage;
        }

        public SuProcessTemplateFlowConditionTypeLanguageModel DeleteProcessTemplateFlowConditionTypeLanguage(int Id)
        {
            var suProcessTemplateFlowConditionTypeLanguage = context.dbProcessTemplateFlowConditionTypeLanguage.Find(Id);
            if (suProcessTemplateFlowConditionTypeLanguage != null)
            {
                context.dbProcessTemplateFlowConditionTypeLanguage.Remove(suProcessTemplateFlowConditionTypeLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateFlowConditionTypeLanguage;
        }

        public IEnumerable<SuProcessTemplateFlowConditionTypeLanguageModel> GetAllProcessTemplateFlowConditionTypeLanguages()
        {
            return context.dbProcessTemplateFlowConditionTypeLanguage;

        }

        public SuProcessTemplateFlowConditionTypeLanguageModel GetProcessTemplateFlowConditionTypeLanguage(int Id)
        {
            return context.dbProcessTemplateFlowConditionTypeLanguage.Find(Id);
        }

        public SuProcessTemplateFlowConditionTypeLanguageModel UpdateProcessTemplateFlowConditionTypeLanguage(SuProcessTemplateFlowConditionTypeLanguageModel suProcessTemplateFlowConditionTypeLanguageChanges)
        {
            var changedProcessTemplateFlowConditionTypeLanguage = context.dbProcessTemplateFlowConditionTypeLanguage.Attach(suProcessTemplateFlowConditionTypeLanguageChanges);
            changedProcessTemplateFlowConditionTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFlowConditionTypeLanguageChanges;

        }
    }
}
