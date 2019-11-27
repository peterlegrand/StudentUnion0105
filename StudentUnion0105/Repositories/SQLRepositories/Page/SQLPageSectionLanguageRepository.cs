using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageSectionLanguageRepository : IPageSectionLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLPageSectionLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }







        public IEnumerable<SuPageSectionLanguageModel> GetAllPageSectionLanguages()
        {
            return context.DbPageSectionLanguage.AsNoTracking().ToList();
        }

        public SuPageSectionLanguageModel GetPageSectionLanguage(int Id)
        {
            return context.DbPageSectionLanguage.Find(Id);
        }




        public SuPageSectionLanguageModel AddPageSectionLanguage(SuPageSectionLanguageModel suPageSectionLanguage)
        {
            context.DbPageSectionLanguage.Add(suPageSectionLanguage);
            context.SaveChanges();
            return suPageSectionLanguage;
        }

        public SuPageSectionLanguageModel UpdatePageSectionLanguage(SuPageSectionLanguageModel suPageSectionLanguageChanges)
        {
            var changedPageSectionLanguage = context.DbPageSectionLanguage.Attach(suPageSectionLanguageChanges);
            changedPageSectionLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageSectionLanguageChanges;
        }

        public SuPageSectionLanguageModel DeletePageSectionLanguage(int Id)
        {
            var suPageSectionLanguage = context.DbPageSectionLanguage.Find(Id);
            if (suPageSectionLanguage != null)
            {
                context.DbPageSectionLanguage.Remove(suPageSectionLanguage);
                context.SaveChanges();

            }
            return suPageSectionLanguage;
        }
    }
}
