using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
   public interface ISettingRepository
    {
        SuSettingModel GetSetting(int Id);
        IEnumerable<SuSettingModel> GetAllSettings();
        SuSettingModel UpdateSetting(SuSettingModel suSettingChanges);
    }
}
