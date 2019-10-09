using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUIScreenRepository : IUIScreenRepository
    {
        private readonly SuDbContext context;

        public SQLUIScreenRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuUIScreenModel> GetAllScreens()
        {
            return context.dbScreen;
        }

        public SuUIScreenModel GetScreen(int Id)
        {
            return context.dbScreen.Find(Id);
        }

    }
}
