using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.dbContentClassificationValue.Add(suContentClassificationValue);
            context.SaveChanges();
            return suContentClassificationValue;
        }

        public SuContentClassificationValueModel DeleteContentClassificationValue(int Id)
        {
           var SuContentClassificationValue =  context.dbContentClassificationValue.Find(Id);
            if(SuContentClassificationValue != null)
            {
                context.dbContentClassificationValue.Remove(SuContentClassificationValue);
                context.SaveChanges();

            }
            return SuContentClassificationValue;
        }

        

        public IEnumerable<SuContentClassificationValueModel> GetAllContentClassificationValues()
        {
            return context.dbContentClassificationValue;
            
        }

        public SuContentClassificationValueModel GetContentClassificationValue(int Id)
        {
            return context.dbContentClassificationValue.Find(Id);
        }

        public SuContentClassificationValueModel UpdateContentClassificationValue(SuContentClassificationValueModel suContentClassificationValueChanges)
        {
           var changedContentClassificationValue = context.dbContentClassificationValue.Attach(suContentClassificationValueChanges);
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
