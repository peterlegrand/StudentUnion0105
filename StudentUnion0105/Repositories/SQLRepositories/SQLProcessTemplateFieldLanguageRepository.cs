using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFieldLanguageRepository : IProcessTemplateFieldLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFieldLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFieldLanguageModel AddProcessTemplateFieldLanguage(SuProcessTemplateFieldLanguageModel suProcessTemplateFieldLanguage)
        {
            context.dbProcessTemplateFieldLanguage.Add(suProcessTemplateFieldLanguage);
            context.SaveChanges();
            return suProcessTemplateFieldLanguage;
        }

        public SuProcessTemplateFieldLanguageModel DeleteProcessTemplateFieldLanguage(int Id)
        {
           var suProcessTemplateFieldLanguage =  context.dbProcessTemplateFieldLanguage.Find(Id);
            if(suProcessTemplateFieldLanguage != null)
            {
                context.dbProcessTemplateFieldLanguage.Remove(suProcessTemplateFieldLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateFieldLanguage;
        }

        public IEnumerable<SuProcessTemplateFieldLanguageModel> GetAllProcessTemplateFieldLanguages()
        {
            return context.dbProcessTemplateFieldLanguage;
            
        }

        public SuProcessTemplateFieldLanguageModel GetProcessTemplateFieldLanguage(int Id)
        {
            return context.dbProcessTemplateFieldLanguage.Find(Id);
        }

        public SuProcessTemplateFieldLanguageModel UpdateProcessTemplateFieldLanguage(SuProcessTemplateFieldLanguageModel suProcessTemplateFieldLanguageChanges)
        {
           var changedProcessTemplateFieldLanguage = context.dbProcessTemplateFieldLanguage.Attach(suProcessTemplateFieldLanguageChanges);
            changedProcessTemplateFieldLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFieldLanguageChanges;

        }
    }
}
