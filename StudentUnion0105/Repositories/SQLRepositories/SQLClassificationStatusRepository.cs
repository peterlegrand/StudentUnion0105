using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationStatusRepository : IClassificationStatusRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationStatusRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuClassificationStatusModel> GetAllClassificationStatus()
        {
            return context.dbClassificationStatus;
            
        }

        public SuClassificationStatusModel GetSuClassificationStatus(int Id)
        {
            return  context.dbClassificationStatus.Find(Id);
        }
    }
}
