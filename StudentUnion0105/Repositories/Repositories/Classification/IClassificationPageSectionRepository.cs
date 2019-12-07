using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationPageSectionRepository
    {
        SuClassificationPageSectionModel GetClassificationPageSection(int Id);
        IEnumerable<SuClassificationPageSectionModel> GetAllClassificationPageSections();
        //        IEnumerable<SuClassificationPageSectionModel> GetAllClassificationPageSectionsOfClass(int Id);
        SuClassificationPageSectionModel AddClassificationPageSection(SuClassificationPageSectionModel suClassificationPageSection);
        SuClassificationPageSectionModel UpdateClassificationPageSection(SuClassificationPageSectionModel suClassificationPageSectionChanges);
        SuClassificationPageSectionModel DeleteClassificationPageSection(int Id);


    }
}
