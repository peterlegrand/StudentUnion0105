using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLDataTypeRepository : IDataTypeRepository
    {
        private readonly SuDbContext _context;

        public SQLDataTypeRepository(SuDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SuDataTypeModel> GetAllDataTypes()
        {
            return _context.dbDataType;

        }

        public SuDataTypeModel GetDataType(int Id)
        {
            return _context.dbDataType.Find(Id);
        }
    }
}
