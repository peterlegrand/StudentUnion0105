using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLContentClassificationValueRepository : IContentClassificationValueRepository
    {
        private readonly SuDbContext context;

        public SQLContentClassificationValueRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuContentClassificationValueModel AddContentClassificationValue(SuContentClassificationValueModel suContentClassificationValue)
        {
            context.DbContentClassificationValue.Add(suContentClassificationValue);
            context.SaveChanges();
            return suContentClassificationValue;
        }

        public SuContentClassificationValueModel DeleteContentClassificationValue(int Id)
        {
            var SuContentClassificationValue = context.DbContentClassificationValue.Find(Id);
            if (SuContentClassificationValue != null)
            {
                context.DbContentClassificationValue.Remove(SuContentClassificationValue);
                context.SaveChanges();

            }
            return SuContentClassificationValue;
        }



        public IEnumerable<SuContentClassificationValueModel> GetAllContentClassificationValues()
        {
            return context.DbContentClassificationValue;

        }

        public SuContentClassificationValueModel GetContentClassificationValue(int Id)
        {
            return context.DbContentClassificationValue.Find(Id);
        }

        public SuContentClassificationValueModel UpdateContentClassificationValue(SuContentClassificationValueModel suContentClassificationValueChanges)
        {
            var changedContentClassificationValue = context.DbContentClassificationValue.Attach(suContentClassificationValueChanges);
            changedContentClassificationValue.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suContentClassificationValueChanges;

        }




        IEnumerable<SuContentClassificationValueModel> IContentClassificationValueRepository.GetAllClassifcationClassificationValues()
        {
            throw new NotImplementedException();
        }

    }
}
