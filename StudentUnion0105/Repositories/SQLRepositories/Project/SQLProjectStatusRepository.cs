using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProjectStatusRepository : IProjectStatusRepository
    {
        private readonly SuDbContext context;

        public SQLProjectStatusRepository(SuDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SuProjectStatusModel> GetAllProjectStatus()
        {
            return context.DbProjectStatus;
        }

        public SuProjectStatusModel GetSuProjectStatus(int Id)
        {
            return context.DbProjectStatus.Find(Id);
        }
    }
}
