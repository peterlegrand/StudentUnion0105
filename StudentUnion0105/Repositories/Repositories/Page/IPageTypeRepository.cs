using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IPageTypeRepository
    {
        SuPageTypeModel GetPageType(int Id);
        IEnumerable<SuPageTypeModel> GetAllPageTypes();
        SuPageTypeModel AddPageType(SuPageTypeModel suPageType);
        SuPageTypeModel UpdatePageType(SuPageTypeModel suPageTypeChanges);
        SuPageTypeModel DeletePageType(int Id);

    }
}
