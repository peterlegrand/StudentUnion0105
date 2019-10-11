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
            context.dbPage.Add(suPage);
            context.SaveChanges();
            return suPage;
        }

        public SuPageModel DeletePage(int Id)
        {
            var suPage = context.dbPage.Find(Id);
            if (suPage != null)
            {
                context.dbPage.Remove(suPage);
                context.SaveChanges();

            }
            return suPage;
        }

        public IEnumerable<SuPageModel> GetAllPages()
        {
            return context.dbPage;
        }

        public SuPageModel GetPage(int Id)
        {
            return context.dbPage.Find(Id);
        }

        public SuPageModel UpdatePage(SuPageModel suPageChanges)
        {
            var changedPage = context.dbPage.Attach(suPageChanges);
            changedPage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageChanges;

        }
    }
}
