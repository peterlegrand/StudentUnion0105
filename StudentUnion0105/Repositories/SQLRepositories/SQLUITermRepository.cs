using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUITermRepository : IUITermRepository
    {
        private readonly SuDbContext context;

        public SQLUITermRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuUITermModel> GetAllTerms()
        {
            return context.dbTerm;
        }

        public SuUITermModel GetTerm(int Id)
        {
            return context.dbTerm.Find(Id);
        }

    }
}
