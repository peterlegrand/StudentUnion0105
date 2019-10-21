using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLObjectRepository : IObjectRepository
    {
        private readonly SuDbContext context;

        public SQLObjectRepository(SuDbContext suContext)
        {
            this.context = suContext;
        }

        public IEnumerable<SuObject> GetAllObjects()
        {
            return context.dbObject;
        }
        public SuObject GetObject(int ID)
        {
            return context.dbObject.Find(ID);
        }

    }
}
