using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationLevelRepository
    {
        SuClassificationLevelModel GetClassificationLevel(int Id);
        IEnumerable<SuClassificationLevelModel> GetAllClassificationLevels();
        SuClassificationLevelModel AddClassificationLevel(SuClassificationLevelModel suClassificationLevel);
        SuClassificationLevelModel UpdateClassificationLevel(SuClassificationLevelModel suClassificationLevelChanges);
        SuClassificationLevelModel DeleteClassificationLevel(int Id);

    }
}
    