using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationPageRepository : IClassificationPageRepository
    {
        private readonly SuDbContext context;


        public SQLClassificationPageRepository(SuDbContext context)
        {

            this.context = context;
            //PETER CURRENT ISSUE
            //      this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public SuClassificationPageModel AddClassificationPage(SuClassificationPageModel suClassificationPage)
        {
            context.DbClassificationPage.Add(suClassificationPage);
            context.SaveChanges();
            //            context.dbClassificationPage.
            return suClassificationPage;
        }

        public SuClassificationPageModel DeleteClassificationPage(int Id)
        {
            var suClassificationPage = context.DbClassificationPage.Find(Id);
            if (suClassificationPage != null)
            {
                context.DbClassificationPage.Remove(suClassificationPage);
                context.SaveChanges();

            }
            return suClassificationPage;

        }

        public IEnumerable<SuClassificationPageModel> GetAllClassificationPages()
        {
            return context.DbClassificationPage;//.AsNoTracking();
        }

        public SuClassificationPageModel GetClassificationPage(int Id)
        {
            return context.DbClassificationPage.Find(Id);
        }

        public SuClassificationPageModel UpdateClassificationPage(SuClassificationPageModel suClassificationPageChanges)
        {
            var suClassificationPage = context.DbClassificationPage.Attach(suClassificationPageChanges);
            suClassificationPage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();
            return suClassificationPageChanges;

        }
    }
}

