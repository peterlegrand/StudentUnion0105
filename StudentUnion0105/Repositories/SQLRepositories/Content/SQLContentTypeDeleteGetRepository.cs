using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLContentTypeDeleteGetRepository : IContentTypeDeleteGetRepository
    {
        private readonly SuDbContext context;

        public SQLContentTypeDeleteGetRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuContentTypeDeleteGetModel GetContentType(int Id)
        {
            return context.dbContentTypeDeleteGet.Find(Id);
        }
    }
}
