using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationLevelVMRepository
    {

        IEnumerable<SuClassificationLevelModel> GetAllClassificationLevels();
        IEnumerable<SuClassificationLevelLanguageModel> GetAllClassificationLevelLanguages();
    }
}
