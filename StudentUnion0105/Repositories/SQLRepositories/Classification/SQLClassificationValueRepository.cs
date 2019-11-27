using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationValueRepository : IClassificationValueRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationValueRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuClassificationValueModel AddClassificationValue(SuClassificationValueModel suClassificationValue)
        {
            context.DbClassificationValue.Add(suClassificationValue);
            context.SaveChanges();
            return suClassificationValue;
        }

        public SuClassificationValueModel DeleteClassificationValue(int Id)
        {
            var suClassificationValue = context.DbClassificationValue.Find(Id);
            if (suClassificationValue != null)
            {
                context.DbClassificationValue.Remove(suClassificationValue);
                context.SaveChanges();

            }
            return suClassificationValue;
        }

        public IEnumerable<SuClassificationValueModel> GetAllClassifcationValues()
        {
            return context.DbClassificationValue;

        }

        public SuClassificationValueModel GetClassificationValue(int Id)
        {
            return context.DbClassificationValue.Find(Id);
        }

        public SuClassificationValueModel UpdateClassificationValue(SuClassificationValueModel suClassificationValueChanges)
        {
            var changedClassificationValue = context.DbClassificationValue.Attach(suClassificationValueChanges);
            changedClassificationValue.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationValueChanges;

        }
    }
}
