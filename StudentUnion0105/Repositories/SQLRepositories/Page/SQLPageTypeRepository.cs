using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageTypeRepository : IPageTypeRepository
    {
        private readonly SuDbContext context;

        public SQLPageTypeRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuPageTypeModel AddPageType(SuPageTypeModel suPageType)
        {
            context.DbPageType.Add(suPageType);
            context.SaveChanges();
            return suPageType;
        }

        public SuPageTypeModel DeletePageType(int Id)
        {
            var suPageType = context.DbPageType.Find(Id);
            if (suPageType != null)
            {
                context.DbPageType.Remove(suPageType);
                context.SaveChanges();

            }
            return suPageType;
        }

        public IEnumerable<SuPageTypeModel> GetAllPageTypes()
        {
            return context.DbPageType;
        }

        public SuPageTypeModel GetPageType(int Id)
        {
            return context.DbPageType.Find(Id);
        }

        public SuPageTypeModel UpdatePageType(SuPageTypeModel suPageTypeChanges)
        {
            var changedPageType = context.DbPageType.Attach(suPageTypeChanges);
            changedPageType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageTypeChanges;

        }
    }
}
