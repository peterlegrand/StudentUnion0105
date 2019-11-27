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
            context.DbContentTypeLanguage.Add(suContentTypeLanguage);
            context.SaveChanges();
            return suContentTypeLanguage;
        }

        public SuContentTypeLanguageModel DeleteContentTypeLanguage(int Id)
        {
            var suContentTypeLanguage = context.DbContentTypeLanguage.Find(Id);
            if (suContentTypeLanguage != null)
            {
                context.DbContentTypeLanguage.Remove(suContentTypeLanguage);
                context.SaveChanges();

            }
            return suContentTypeLanguage;
        }

        public IEnumerable<SuContentTypeLanguageModel> GetAllContentTypeLanguages()
        {
            return context.DbContentTypeLanguage;
        }

        public SuContentTypeLanguageModel GetContentTypeLanguage(int Id)
        {
            return context.DbContentTypeLanguage.Find(Id);
        }

        public SuContentTypeLanguageModel UpdateContentTypeLanguage(SuContentTypeLanguageModel suContentTypeLanguageChanges)
        {
            var suContentTypeLanguage = context.DbContentTypeLanguage.Attach(suContentTypeLanguageChanges);
            suContentTypeLanguage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suContentTypeLanguageChanges;
        }
    }
}
