using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateFieldTypeLanguageRepository : IProcessTemplateFieldTypeLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateFieldTypeLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateFieldTypeLanguageModel AddProcessTemplateFieldTypeLanguage(SuProcessTemplateFieldTypeLanguageModel suProcessTemplateFieldTypeLanguage)
        {
            context.dbProcessTemplateFieldTypeLanguage.Add(suProcessTemplateFieldTypeLanguage);
            context.SaveChanges();
            return suProcessTemplateFieldTypeLanguage;
        }

        public SuProcessTemplateFieldTypeLanguageModel DeleteProcessTemplateFieldTypeLanguage(int Id)
        {
           var suProcessTemplateFieldTypeLanguage =  context.dbProcessTemplateFieldTypeLanguage.Find(Id);
            if(suProcessTemplateFieldTypeLanguage != null)
            {
                context.dbProcessTemplateFieldTypeLanguage.Remove(suProcessTemplateFieldTypeLanguage);
                context.SaveChanges();

            }
            return suProcessTemplateFieldTypeLanguage;
        }

        public IEnumerable<SuProcessTemplateFieldTypeLanguageModel> GetAllProcessTemplateFieldTypeLanguages()
        {
            return context.dbProcessTemplateFieldTypeLanguage;
            
        }

        public SuProcessTemplateFieldTypeLanguageModel GetProcessTemplateFieldTypeLanguage(int Id)
        {
            return context.dbProcessTemplateFieldTypeLanguage.Find(Id);
        }

        public SuProcessTemplateFieldTypeLanguageModel UpdateProcessTemplateFieldTypeLanguage(SuProcessTemplateFieldTypeLanguageModel suProcessTemplateFieldTypeLanguageChanges)
        {
           var changedProcessTemplateFieldTypeLanguage = context.dbProcessTemplateFieldTypeLanguage.Attach(suProcessTemplateFieldTypeLanguageChanges);
            changedProcessTemplateFieldTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateFieldTypeLanguageChanges;

        }
    }
}
