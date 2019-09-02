using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageStatusRepository : IPageStatusRepository
    {
        private readonly SuDbContext context;

        public SQLPageStatusRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuPageStatusModel> GetAllPageStatus()
        {
            return context.dbPageStatus;
        }

        public SuPageStatusModel GetSuPageStatus(int Id)
        {
            return context.dbPageStatus.Find(Id);
        }
    }
}
