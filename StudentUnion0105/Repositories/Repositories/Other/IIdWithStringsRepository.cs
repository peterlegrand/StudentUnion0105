using StudentUnion0105.Models;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IIdWithStringsRepository
    {
        SuIdWithStrings GetIdWithStrings(int Id);
        IEnumerable<SuIdWithStrings> GetAllIdWithStringss();
    }
}
