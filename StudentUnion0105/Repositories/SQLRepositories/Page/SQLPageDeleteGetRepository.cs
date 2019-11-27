using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageDeleteGetRepository : IPageDeleteGetRepository
    {
        private readonly SuDbContext context;

        public SQLPageDeleteGetRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuPageDeleteGetModel GetPage(int Id)
        {
            return context.DbPageDeleteGet.Find(Id);
        }
    }
}
