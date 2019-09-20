using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
