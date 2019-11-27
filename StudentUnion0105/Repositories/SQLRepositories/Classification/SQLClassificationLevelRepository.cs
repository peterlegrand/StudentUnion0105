using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationLevelRepository : IClassificationLevelRepository
    {
        private readonly SuDbContext context;


        public SQLClassificationLevelRepository(SuDbContext context)
        {

            this.context = context;
            //PETER CURRENT ISSUE
            //      this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public SuClassificationLevelModel AddClassificationLevel(SuClassificationLevelModel suClassificationLevel)
        {
            context.DbClassificationLevel.Add(suClassificationLevel);
            context.SaveChanges();
            //            context.dbClassificationLevel.
            return suClassificationLevel;
        }

        public SuClassificationLevelModel DeleteClassificationLevel(int Id)
        {
            var suClassificationLevel = context.DbClassificationLevel.Find(Id);
            if (suClassificationLevel != null)
            {
                context.DbClassificationLevel.Remove(suClassificationLevel);
                context.SaveChanges();

            }
            return suClassificationLevel;

        }

        public IEnumerable<SuClassificationLevelModel> GetAllClassificationLevels()
        {
            return context.DbClassificationLevel;//.AsNoTracking();
        }

        public SuClassificationLevelModel GetClassificationLevel(int Id)
        {
            return context.DbClassificationLevel.Find(Id);
        }

        public SuClassificationLevelModel UpdateClassificationLevel(SuClassificationLevelModel suClassificationLevelChanges)
        {
            var suClassificationLevel = context.DbClassificationLevel.Attach(suClassificationLevelChanges);
            suClassificationLevel.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();
            return suClassificationLevelChanges;

        }
    }
}

