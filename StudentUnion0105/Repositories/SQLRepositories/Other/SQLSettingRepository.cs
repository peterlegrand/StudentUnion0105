using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLSettingRepository : ISettingRepository
    {
        private readonly SuDbContext Context;

        public SQLSettingRepository(SuDbContext context)
        {
            this.Context = context;
        }


        public IEnumerable<SuSettingModel> GetAllSettings()
        {
            return Context.DbSetting;
        }

        public SuSettingModel GetSetting(int Id)
        {
            return Context.DbSetting.Find(Id);
        }
        public SuSettingModel UpdateSetting(SuSettingModel suSettingChanges)
        {
            var changedSetting = Context.DbSetting.Attach(suSettingChanges);
            changedSetting.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return suSettingChanges;

        }

    }

}
