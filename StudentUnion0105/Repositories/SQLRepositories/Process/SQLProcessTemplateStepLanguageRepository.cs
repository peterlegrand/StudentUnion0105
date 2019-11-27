using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateStepLanguageRepository : IProcessTemplateStepLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateStepLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateStepLanguageModel AddProcessTemplateStepLanguage(SuProcessTemplateStepLanguageModel suProcessTemplateStepLanguage)
        {
            context.DbProcessTemplateStepLanguage.Add(suProcessTemplateStepLanguage);
            context.SaveChanges();
            return suProcessTemplateStepLanguage;
        }

        public SuProcessTemplateStepLanguageModel DeleteProcessTemplateStepLanguage(int Id)
        {
            var suProcessTemplateStepLanguage = context.DbProcessTemplateStepLanguage.Find(Id);
            if (suProcessTemplateStepLanguage != null)
            {
                context.DbProcessTemplateStepLanguage.Remove(suProcessTemplateStepLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateStepLanguage;
        }

        public IEnumerable<SuProcessTemplateStepLanguageModel> GetAllProcessTemplateStepLanguages()
        {
            return context.DbProcessTemplateStepLanguage;

        }

        public SuProcessTemplateStepLanguageModel GetProcessTemplateStepLanguage(int Id)
        {
            return context.DbProcessTemplateStepLanguage.Find(Id);
        }

        public SuProcessTemplateStepLanguageModel UpdateProcessTemplateStepLanguage(SuProcessTemplateStepLanguageModel suProcessTemplateStepLanguageChanges)
        {
            var changedProcessTemplateStepLanguage = context.DbProcessTemplateStepLanguage.Attach(suProcessTemplateStepLanguageChanges);
            changedProcessTemplateStepLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateStepLanguageChanges;

        }
    }
}
