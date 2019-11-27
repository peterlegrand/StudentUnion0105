using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationStatusRepository : IClassificationStatusRepository
    {
        private readonly SuDbContext _context;

        public SQLClassificationStatusRepository(SuDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SuClassificationStatusModel> GetAllClassificationStatus()
        {
            return _context.DbClassificationStatus;

        }

        public SuClassificationStatusModel GetSuClassificationStatus(int Id)
        {
            return _context.DbClassificationStatus.Find(Id);
        }
    }
}
