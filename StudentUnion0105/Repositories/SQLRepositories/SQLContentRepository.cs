using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.dbContent.Add(suContent);
            context.SaveChanges();
            return suContent;
        }

        public SuContentModel DeleteContent(int Id)
        {
           var suContent =  context.dbContent.Find(Id);
            if(suContent != null)
            {
                context.dbContent.Remove(suContent);
                context.SaveChanges();

            }
            return suContent;
        }

        public IEnumerable<SuContentModel> GetAllClassifcations()
        {
            return context.dbContent;
            
        }

        public SuContentModel GetContent(int Id)
        {
            return context.dbContent.Find(Id);
        }

        public SuContentModel UpdateContent(SuContentModel suContentChanges)
        {
           var changedContent = context.dbContent.Attach(suContentChanges);
            changedContent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suContentChanges;

        }
    }
}
