using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IContentRepository
    {
        SuContentModel GetContent(int Id);
        IEnumerable<SuContentModel> GetAllClassifcations();
        SuContentModel AddContent(SuContentModel suContent);
        SuContentModel UpdateContent(SuContentModel suContentChanges);
        SuContentModel DeleteContent(int Id);
    }
}
