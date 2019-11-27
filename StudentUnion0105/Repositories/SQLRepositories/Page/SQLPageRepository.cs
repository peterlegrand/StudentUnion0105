using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageRepository : IPageRepository
    {
        private readonly SuDbContext context;

        public SQLPageRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuPageModel AddPage(SuPageModel suPage)
        {
            context.DbPage.Add(suPage);
            context.SaveChanges();
            return suPage;
        }

        public SuPageModel DeletePage(int Id)
        {
            var suPage = context.DbPage.Find(Id);
            if (suPage != null)
            {
                context.DbPage.Remove(suPage);
                context.SaveChanges();

            }
            return suPage;
        }

        public IEnumerable<SuPageModel> GetAllPages()
        {
            return context.DbPage;
        }

        public SuPageModel GetPage(int Id)
        {
            return context.DbPage.Find(Id);
        }

        public SuPageModel UpdatePage(SuPageModel suPageChanges)
        {
            var changedPage = context.DbPage.Attach(suPageChanges);
            changedPage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageChanges;

        }
    }
}
