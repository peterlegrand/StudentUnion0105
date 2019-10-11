using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IMasterListRepository
    {
        SuMasterListModel GetMasterList(int Id);
        IEnumerable<SuMasterListModel> GetAllMasterLists();


    }
}
