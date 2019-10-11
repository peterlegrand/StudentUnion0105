using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IPageRepository
    {
        SuPageModel GetPage(int Id);
        IEnumerable<SuPageModel> GetAllPages();
        SuPageModel AddPage(SuPageModel suPage);
        SuPageModel UpdatePage(SuPageModel suPageChanges);
        SuPageModel DeletePage(int Id);

    }
}
