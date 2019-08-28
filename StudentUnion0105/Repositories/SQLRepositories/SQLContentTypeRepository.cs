using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLContentTypeRepository : IContentTypeRepository
    {
        private readonly SuDbContext context;

        public SQLContentTypeRepository( SuDbContext context)
        {
            this.context = context;
        }
        public SuContentTypeModel AddContentType(SuContentTypeModel suContentType)
        {
            context.dbContentType.Add(suContentType);
            context.SaveChanges();
            return suContentType;
        }

        public SuContentTypeModel DeleteContentType(int Id)
        {
            var suContentType = context.dbContentType.Find(Id);
            if (suContentType != null)
            {
                context.dbContentType.Remove(suContentType);
                context.SaveChanges();

            }
            return suContentType;
        }

        public IEnumerable<SuContentTypeModel> GetAllContentTypes()
        {
            return context.dbContentType;

        }

        public SuContentTypeModel GetContentType(int Id)
        {
            return context.dbContentType.Find(Id);
        }

        public SuContentTypeModel UpdateContentType(SuContentTypeModel suContentTypeChanges)
        {
            var changedContentType = context.dbContentType.Attach(suContentTypeChanges);
            changedContentType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suContentTypeChanges;
        }
    }
}
