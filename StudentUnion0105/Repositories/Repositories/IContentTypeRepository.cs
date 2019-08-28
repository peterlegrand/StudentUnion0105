using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    interface IContentTypeRepository
    {
        SuContentTypeModel GetContentType(int Id);
        IEnumerable<SuContentTypeModel> GetAllContentTypes();
        SuContentTypeModel AddContentType(SuContentTypeModel suContentType);
        SuContentTypeModel UpdateContentType(SuContentTypeModel suContentTypeChanges);
        SuContentTypeModel DeleteContentType(int Id);
    }
}
