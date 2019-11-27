using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationRepository : IClassificationRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuClassificationModel AddClassification(SuClassificationModel suClassification)
        {
            context.DbClassification.Add(suClassification);
            context.SaveChanges();
            return suClassification;
        }

        public SuClassificationModel DeleteClassification(int Id)
        {
            var suClassification = context.DbClassification.Find(Id);
            if (suClassification != null)
            {
                context.DbClassification.Remove(suClassification);
                context.SaveChanges();

            }
            return suClassification;
        }

        public IEnumerable<SuClassificationModel> GetAllClassifcations()
        {
            return context.DbClassification;

        }

        public SuClassificationModel GetClassification(int Id)
        {
            return context.DbClassification.Find(Id);
        }

        public SuClassificationModel UpdateClassification(SuClassificationModel suClassificationChanges)
        {
            var changedClassification = context.DbClassification.Attach(suClassificationChanges);
            changedClassification.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationChanges;

        }
    }
}
