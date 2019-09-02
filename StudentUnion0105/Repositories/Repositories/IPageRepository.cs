using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public  interface IPageRepository
    {
        SuPageModel GetPage(int Id);
        IEnumerable<SuPageModel> GetAllPages();
        SuPageModel AddPage(SuPageModel suPage);
        SuPageModel UpdatePage(SuPageModel suPageChanges);
        SuPageModel DeletePage(int Id);

    }
}
