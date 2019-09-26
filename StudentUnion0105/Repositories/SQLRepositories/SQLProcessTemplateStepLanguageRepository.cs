using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.dbProcessTemplateStepLanguage.Add(suProcessTemplateStepLanguage);
            context.SaveChanges();
            return suProcessTemplateStepLanguage;
        }

        public SuProcessTemplateStepLanguageModel DeleteProcessTemplateStepLanguage(int Id)
        {
           var suProcessTemplateStepLanguage =  context.dbProcessTemplateStepLanguage.Find(Id);
            if(suProcessTemplateStepLanguage != null)
            {
                context.dbProcessTemplateStepLanguage.Remove(suProcessTemplateStepLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateStepLanguage;
        }

        public IEnumerable<SuProcessTemplateStepLanguageModel> GetAllProcessTemplateStepLanguages()
        {
            return context.dbProcessTemplateStepLanguage;
            
        }

        public SuProcessTemplateStepLanguageModel GetProcessTemplateStepLanguage(int Id)
        {
            return context.dbProcessTemplateStepLanguage.Find(Id);
        }

        public SuProcessTemplateStepLanguageModel UpdateProcessTemplateStepLanguage(SuProcessTemplateStepLanguageModel suProcessTemplateStepLanguageChanges)
        {
           var changedProcessTemplateStepLanguage = context.dbProcessTemplateStepLanguage.Attach(suProcessTemplateStepLanguageChanges);
            changedProcessTemplateStepLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateStepLanguageChanges;

        }
    }
}
