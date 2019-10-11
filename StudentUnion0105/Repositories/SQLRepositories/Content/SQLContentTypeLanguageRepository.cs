using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLContentTypeLanguageRepository : IContentTypeLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLContentTypeLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuContentTypeLanguageModel AddContentTypeLanguage(SuContentTypeLanguageModel suContentTypeLanguage)
        {
            context.dbContentTypeLanguage.Add(suContentTypeLanguage);
            context.SaveChanges();
            return suContentTypeLanguage;
        }

        public SuContentTypeLanguageModel DeleteContentTypeLanguage(int Id)
        {
            var suContentTypeLanguage = context.dbContentTypeLanguage.Find(Id);
            if (suContentTypeLanguage != null)
            {
                context.dbContentTypeLanguage.Remove(suContentTypeLanguage);
                context.SaveChanges();

            }
            return suContentTypeLanguage;
        }

        public IEnumerable<SuContentTypeLanguageModel> GetAllContentTypeLanguages()
        {
            return context.dbContentTypeLanguage;
        }

        public SuContentTypeLanguageModel GetContentTypeLanguage(int Id)
        {
            return context.dbContentTypeLanguage.Find(Id);
        }

        public SuContentTypeLanguageModel UpdateContentTypeLanguage(SuContentTypeLanguageModel suContentTypeLanguageChanges)
        {
            var suContentTypeLanguage = context.dbContentTypeLanguage.Attach(suContentTypeLanguageChanges);
            suContentTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suContentTypeLanguageChanges;
        }
    }
}
