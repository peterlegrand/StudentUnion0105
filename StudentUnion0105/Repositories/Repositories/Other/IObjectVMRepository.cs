using StudentUnion0105.Models;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IObjectVMRepository
    {
        SuObjectVM GetObjectVM(int Id);
        IEnumerable<SuObjectVM> GetAllObjectVMs();
    }
}
