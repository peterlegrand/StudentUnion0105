using StudentUnion0105.Models;
using System.Collections.Generic;


namespace StudentUnion0105.Repositories
{
    public interface IPageSectionTypeRepository
    {

        SuPageSectionTypeModel GetPageSectionType(int Id);
        IEnumerable<SuPageSectionTypeModel> GetAllPageSectionTypes();
        SuPageSectionTypeModel AddPageSectionType(SuPageSectionTypeModel suPageSectionType);
        SuPageSectionTypeModel UpdatePageSectionType(SuPageSectionTypeModel suPageSectionTypeChanges);
        SuPageSectionTypeModel DeletePageSectionType(int Id);
    }
}
