using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLObjectVMRepository : IObjectVMRepository
    {
        private readonly SuDbContext context;

        public SQLObjectVMRepository(SuDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<SuObjectVM> GetAllObjectVMs()
        {
            return context.DbObjectVM;
        }

        public SuObjectVM GetObjectVM(int Id)
        {
            return context.DbObjectVM.Find(Id);
        }

    }
}
