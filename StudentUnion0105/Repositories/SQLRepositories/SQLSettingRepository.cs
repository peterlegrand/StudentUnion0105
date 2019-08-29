using StudentUnion0105.Repositories;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLSettingRepository : ISettingRepository
    {
        private readonly SuDbContext Context;

        public SQLSettingRepository(SuDbContext context)
        {
            this.Context = context;
        }


        IEnumerable<SuSettingModel> ISettingRepository.GetAllSettings()
        {
            return Context.dbSetting;
        }

        SuSettingModel ISettingRepository.GetSetting(int Id)
        {
            return Context.dbSetting.Find(Id);
        }
    }

}
