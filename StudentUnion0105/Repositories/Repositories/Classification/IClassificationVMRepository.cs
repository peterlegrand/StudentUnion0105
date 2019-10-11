using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationVMRepository
    {
        IEnumerable<SuClassificationModel> GetAllClassifications();
        IEnumerable<SuClassificationLanguageModel> GetAllClassificationLanguages();


    }
}
