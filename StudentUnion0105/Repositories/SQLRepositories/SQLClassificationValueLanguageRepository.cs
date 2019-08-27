using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationValueLanguageRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationValueLanguageRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuClassificationValueModel AddClassificationValue(SuClassificationValueModel suClassificationValue)
        {
            context.dbClassificationValue.Add(suClassificationValue);
            context.SaveChanges();
            return suClassificationValue;
        }

        public SuClassificationValueModel DeleteClassificationValue(int Id)
        {
            var suClassificationValue = context.dbClassificationValue.Find(Id);
            if (suClassificationValue != null)
            {
                context.dbClassificationValue.Remove(suClassificationValue);
                context.SaveChanges();

            }
            return suClassificationValue;
        }

        public IEnumerable<SuClassificationValueModel> GetAllClassifcationValues()
        {
            return context.dbClassificationValue;

        }

        public SuClassificationValueModel GetClassificationValue(int Id)
        {
            return context.dbClassificationValue.Find(Id);
        }

        public SuClassificationValueModel UpdateClassificationValue(SuClassificationValueModel suClassificationValueChanges)
        {
            var changedClassificationValue = context.dbClassificationValue.Attach(suClassificationValueChanges);
            changedClassificationValue.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationValueChanges;

        }

    }
}
