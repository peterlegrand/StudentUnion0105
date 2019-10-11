using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IContentTypeRepository
    {
        SuContentTypeModel GetContentType(int Id);
        IEnumerable<SuContentTypeModel> GetAllContentTypes();
        SuContentTypeModel AddContentType(SuContentTypeModel suContentType);
        SuContentTypeModel UpdateContentType(SuContentTypeModel suContentTypeChanges);
        SuContentTypeModel DeleteContentType(int Id);
    }
}
