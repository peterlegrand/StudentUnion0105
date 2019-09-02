using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
