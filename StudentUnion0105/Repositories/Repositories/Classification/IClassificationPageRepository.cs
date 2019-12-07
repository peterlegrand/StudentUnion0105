using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationPageRepository
    {
        SuClassificationPageModel GetClassificationPage(int Id);
        IEnumerable<SuClassificationPageModel> GetAllClassificationPages();
        //        IEnumerable<SuClassificationPageModel> GetAllClassificationPagesOfClass(int Id);
        SuClassificationPageModel AddClassificationPage(SuClassificationPageModel suClassificationPage);
        SuClassificationPageModel UpdateClassificationPage(SuClassificationPageModel suClassificationPageChanges);
        SuClassificationPageModel DeleteClassificationPage(int Id);


    }
}
