using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUITermScreenRepository : IUITermScreenRepository
    {
        private readonly SuDbContext context;

        public SQLUITermScreenRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuUITermScreenModel> GetAllTermScreens()
        {
            return context.dbUITermScreen;
        }

        public SuUITermScreenModel GetTermScreen(int Id)
        {
            return context.dbUITermScreen.Find(Id);
        }

    }
}
