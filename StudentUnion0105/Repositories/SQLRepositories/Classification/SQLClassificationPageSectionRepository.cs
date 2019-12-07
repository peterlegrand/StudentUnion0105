using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationPageSectionRepository : IClassificationPageSectionRepository
    {
        private readonly SuDbContext context;


        public SQLClassificationPageSectionRepository(SuDbContext context)
        {

            this.context = context;
            //PETER CURRENT ISSUE
            //      this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public SuClassificationPageSectionModel AddClassificationPageSection(SuClassificationPageSectionModel suClassificationPageSection)
        {
            context.DbClassificationPageSection.Add(suClassificationPageSection);
            context.SaveChanges();
            //            context.dbClassificationPageSection.
            return suClassificationPageSection;
        }

        public SuClassificationPageSectionModel DeleteClassificationPageSection(int Id)
        {
            var suClassificationPageSection = context.DbClassificationPageSection.Find(Id);
            if (suClassificationPageSection != null)
            {
                context.DbClassificationPageSection.Remove(suClassificationPageSection);
                context.SaveChanges();

            }
            return suClassificationPageSection;

        }

        public IEnumerable<SuClassificationPageSectionModel> GetAllClassificationPageSections()
        {
            return context.DbClassificationPageSection;//.AsNoTracking();
        }

        public SuClassificationPageSectionModel GetClassificationPageSection(int Id)
        {
            return context.DbClassificationPageSection.Find(Id);
        }

        public SuClassificationPageSectionModel UpdateClassificationPageSection(SuClassificationPageSectionModel suClassificationPageSectionChanges)
        {
            var suClassificationPageSection = context.DbClassificationPageSection.Attach(suClassificationPageSectionChanges);
            suClassificationPageSection.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();
            return suClassificationPageSectionChanges;

        }
    }
}

