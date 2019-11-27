using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLContentRepository : IContentRepository
    {
        private readonly SuDbContext context;

        public SQLContentRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuContentModel AddContent(SuContentModel suContent)
        {
            context.DbContent.Add(suContent);
            context.SaveChanges();
            return suContent;
        }

        public SuContentModel DeleteContent(int Id)
        {
            var suContent = context.DbContent.Find(Id);
            if (suContent != null)
            {
                context.DbContent.Remove(suContent);
                context.SaveChanges();

            }
            return suContent;
        }

        public IEnumerable<SuContentModel> GetAllClassifcations()
        {
            return context.DbContent;

        }

        public SuContentModel GetContent(int Id)
        {
            return context.DbContent.Find(Id);
        }

        public SuContentModel UpdateContent(SuContentModel suContentChanges)
        {
            var changedContent = context.DbContent.Attach(suContentChanges);
            changedContent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suContentChanges;

        }
    }
}
