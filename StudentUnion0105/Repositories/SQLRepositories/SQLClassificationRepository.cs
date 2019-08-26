using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.dbClassification.Add(suClassification);
            context.SaveChanges();
            return suClassification;
        }

        public SuClassificationModel DeleteClassification(int Id)
        {
           var suClassification =  context.dbClassification.Find(Id);
            if(suClassification != null)
            {
                context.dbClassification.Remove(suClassification);
                context.SaveChanges();

            }
            return suClassification;
        }

        public IEnumerable<SuClassificationModel> GetAllClassifcations()
        {
            return context.dbClassification;
            
        }

        public SuClassificationModel GetClassification(int Id)
        {
            return context.dbClassification.Find(Id);
        }

        public SuClassificationModel UpdateClassification(SuClassificationModel suClassificationChanges)
        {
           var changedClassification = context.dbClassification.Attach(suClassificationChanges);
            changedClassification.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suClassificationChanges;

        }
    }
}
