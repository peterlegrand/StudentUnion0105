using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLMasterListRepository : IMasterListRepository
    {
        private readonly SuDbContext _context;

        public SQLMasterListRepository(SuDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SuMasterListModel> GetAllMasterLists()
        {
            return _context.ZDbMasterList;

        }

        public SuMasterListModel GetMasterList(int Id)
        {
            return _context.ZDbMasterList.Find(Id);
        }
    }
}
