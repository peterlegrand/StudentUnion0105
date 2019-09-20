using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageSectionLanguageRepository: IPageSectionLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLPageSectionLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }

       

      

       

        public IEnumerable<SuPageSectionLanguageModel> GetAllPageSectionLanguages()
        {
            return context.dbPageSectionLanguage.AsNoTracking().ToList();
        }

        public SuPageSectionLanguageModel GetPageSectionLanguage(int Id)
        {
            return context.dbPageSectionLanguage.Find(Id);
        }

      


        public SuPageSectionLanguageModel AddPageSectionLanguage(SuPageSectionLanguageModel suPageSectionLanguage)
        {
            context.dbPageSectionLanguage.Add(suPageSectionLanguage);
            context.SaveChanges();
            return suPageSectionLanguage;       }

        public SuPageSectionLanguageModel UpdatePageSectionLanguage(SuPageSectionLanguageModel suPageSectionLanguageChanges)
        {
            var changedPageSectionLanguage = context.dbPageSectionLanguage.Attach(suPageSectionLanguageChanges);
            changedPageSectionLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageSectionLanguageChanges;
        }

        public SuPageSectionLanguageModel DeletePageSectionLanguage(int Id)
        {
            var suPageSectionLanguage = context.dbPageSectionLanguage.Find(Id);
            if (suPageSectionLanguage != null)
            {
                context.dbPageSectionLanguage.Remove(suPageSectionLanguage);
                context.SaveChanges();

            }
            return suPageSectionLanguage;
        }
    }
}
