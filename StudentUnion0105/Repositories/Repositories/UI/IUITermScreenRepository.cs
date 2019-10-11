using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUITermScreenRepository
    {
        SuUITermScreenModel GetTermScreen(int Id);
        IEnumerable<SuUITermScreenModel> GetAllTermScreens();


    }
}
