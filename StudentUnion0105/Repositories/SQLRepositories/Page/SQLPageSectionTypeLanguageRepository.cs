using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageSectionTypeLanguageRepository : IPageSectionTypeLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLPageSectionTypeLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }







        public IEnumerable<SuPageSectionTypeLanguageModel> GetAllPageSectionTypeLanguages()
        {
            return context.DbPageSectionTypeLanguage;
        }

        public SuPageSectionTypeLanguageModel GetPageSectionTypeLanguage(int Id)
        {
            return context.DbPageSectionTypeLanguage.Find(Id);
        }




        public SuPageSectionTypeLanguageModel AddPageSectionTypeLanguage(SuPageSectionTypeLanguageModel suPageSectionTypeLanguage)
        {
            context.DbPageSectionTypeLanguage.Add(suPageSectionTypeLanguage);
            context.SaveChanges();
            return suPageSectionTypeLanguage;
        }

        public SuPageSectionTypeLanguageModel UpdatePageSectionTypeLanguage(SuPageSectionTypeLanguageModel suPageSectionTypeLanguageChanges)
        {
            var changedPageSectionTypeLanguage = context.DbPageSectionTypeLanguage.Attach(suPageSectionTypeLanguageChanges);
            changedPageSectionTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageSectionTypeLanguageChanges;
        }

        public SuPageSectionTypeLanguageModel DeletePageSectionTypeLanguage(int Id)
        {
            var suPageSectionTypeLanguage = context.DbPageSectionTypeLanguage.Find(Id);
            if (suPageSectionTypeLanguage != null)
            {
                context.DbPageSectionTypeLanguage.Remove(suPageSectionTypeLanguage);
                context.SaveChanges();

            }
            return suPageSectionTypeLanguage;
        }
    }
}
