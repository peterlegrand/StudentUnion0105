using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLContentTypeRepository : IContentTypeRepository
    {
        private readonly SuDbContext context;

        public SQLContentTypeRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuContentTypeModel AddContentType(SuContentTypeModel suContentType)
        {
            context.DbContentType.Add(suContentType);
            context.SaveChanges();
            return suContentType;
        }

        public SuContentTypeModel DeleteContentType(int Id)
        {
            var suContentType = context.DbContentType.Find(Id);
            if (suContentType != null)
            {
                context.DbContentType.Remove(suContentType);
                context.SaveChanges();

            }
            return suContentType;
        }

        public IEnumerable<SuContentTypeModel> GetAllContentTypes()
        {
            return context.DbContentType;

        }

        public SuContentTypeModel GetContentType(int Id)
        {
            return context.DbContentType.Find(Id);
        }

        public SuContentTypeModel UpdateContentType(SuContentTypeModel suContentTypeChanges)
        {
            var changedContentType = context.DbContentType.Attach(suContentTypeChanges);
            changedContentType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suContentTypeChanges;
        }
    }
}
