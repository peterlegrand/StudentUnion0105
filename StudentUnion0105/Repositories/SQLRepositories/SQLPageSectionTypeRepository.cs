using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageSectionTypeRepository : IPageSectionTypeRepository
    {
        private readonly SuDbContext context;

        public SQLPageSectionTypeRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuPageSectionTypeModel AddPageSectionType(SuPageSectionTypeModel suPageSectionType)
        {
            context.dbPageSectionType.Add(suPageSectionType);
            context.SaveChanges();
            return suPageSectionType;
        }

        public SuPageSectionTypeModel DeletePageSectionType(int Id)
        {
            var suPageSectionType = context.dbPageSectionType.Find(Id);
            if (suPageSectionType != null)
            {
                context.dbPageSectionType.Remove(suPageSectionType);
                context.SaveChanges();

            }
            return suPageSectionType;
        }

        public IEnumerable<SuPageSectionTypeModel> GetAllPageSectionTypes()
        {
            return context.dbPageSectionType;
        }

        public SuPageSectionTypeModel GetPageSectionType(int Id)
        {
            return context.dbPageSectionType.Find(Id);
        }

        public SuPageSectionTypeModel UpdatePageSectionType(SuPageSectionTypeModel suPageSectionTypeChanges)
        {
            var changedPageSectionType = context.dbPageSectionType.Attach(suPageSectionTypeChanges);
            changedPageSectionType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageSectionTypeChanges;
        }


    }
}
