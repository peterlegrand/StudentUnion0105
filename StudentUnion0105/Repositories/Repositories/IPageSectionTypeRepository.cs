using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentUnion0105.Repositories
{
    public  interface IPageSectionTypeRepository
    {

        SuPageSectionTypeModel GetPageSectionType(int Id);
        IEnumerable<SuPageSectionTypeModel> GetAllPageSectionTypes();
        SuPageSectionTypeModel AddPageSectionType(SuPageSectionTypeModel suPageSectionType);
        SuPageSectionTypeModel UpdatePageSectionType(SuPageSectionTypeModel suPageSectionTypeChanges);
        SuPageSectionTypeModel DeletePageSectionType(int Id);
    }
}
