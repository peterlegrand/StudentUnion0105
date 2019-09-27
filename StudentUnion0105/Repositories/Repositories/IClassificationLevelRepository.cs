using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationLevelRepository
    {
        SuClassificationLevelModel GetClassificationLevel(int Id);
        IEnumerable<SuClassificationLevelModel> GetAllClassificationLevels();
        //        IEnumerable<SuClassificationLevelModel> GetAllClassificationLevelsOfClass(int Id);
        SuClassificationLevelModel AddClassificationLevel(SuClassificationLevelModel suClassificationLevel);
        SuClassificationLevelModel UpdateClassificationLevel(SuClassificationLevelModel suClassificationLevelChanges);
        SuClassificationLevelModel DeleteClassificationLevel(int Id);


    }
}
