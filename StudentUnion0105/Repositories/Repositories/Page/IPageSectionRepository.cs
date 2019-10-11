using StudentUnion0105.Models;
using System.Collections.Generic;


namespace StudentUnion0105.Repositories
{
    public interface IPageSectionRepository
    {

        SuPageSectionModel GetPageSection(int Id);
        IEnumerable<SuPageSectionModel> GetAllPageSections();
        SuPageSectionModel AddPageSection(SuPageSectionModel suPageSection);
        SuPageSectionModel UpdatePageSection(SuPageSectionModel suPageSectionChanges);
        SuPageSectionModel DeletePageSection(int Id);
    }
}
