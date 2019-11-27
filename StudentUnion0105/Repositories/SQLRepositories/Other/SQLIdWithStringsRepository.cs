using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLIdWithStringsRepository : IIdWithStringsRepository
    {
        private readonly SuDbContext context;

        public SQLIdWithStringsRepository(SuDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<SuIdWithStrings> GetAllIdWithStringss()
        {
            return context.DbIdWithStrings;
        }

        public SuIdWithStrings GetIdWithStrings(int Id)
        {
            return context.DbIdWithStrings.Find(Id);
        }

    }
}
