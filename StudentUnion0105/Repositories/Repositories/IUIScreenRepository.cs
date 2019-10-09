using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUIScreenRepository
    {
        SuUIScreenModel GetScreen(int Id);
        IEnumerable<SuUIScreenModel> GetAllScreens();


    }
}
