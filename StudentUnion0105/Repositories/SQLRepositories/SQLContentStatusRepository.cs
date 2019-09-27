using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLContentStatusRepository : IContentStatusRepository
    {
        private readonly SuDbContext context;

        public SQLContentStatusRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuContentStatusModel> GetAllContentStatus()
        {
            return context.dbContentStatus;

        }

        public SuContentStatusModel GetSuContentStatus(int Id)
        {
            return context.dbContentStatus.Find(Id);
        }
    }
}
