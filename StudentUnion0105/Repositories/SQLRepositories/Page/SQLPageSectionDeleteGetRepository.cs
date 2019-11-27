using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageSectionDeleteGetRepository : IPageSectionDeleteGetRepository
    {
        private readonly SuDbContext context;

        public SQLPageSectionDeleteGetRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuPageSectionDeleteGetModel GetPageSection(int Id)
        {
            return context.DbPageSectionDeleteGet.Find(Id);
        }
    }
}
