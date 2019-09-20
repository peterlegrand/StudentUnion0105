using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageSectionRepository: IPageSectionRepository
    {
        private readonly SuDbContext context;

        public SQLPageSectionRepository(SuDbContext context)
        {
            this.context = context;
        }

        public SuPageSectionModel AddPageSection(SuPageSectionModel suPageSection)
        {
            context.dbPageSection.Add(suPageSection);
            context.SaveChanges();
            return suPageSection;
        }

        public SuPageSectionModel DeletePageSection(int Id)
        {
            var suPageSection = context.dbPageSection.Find(Id);
            if (suPageSection != null)
            {
                context.dbPageSection.Remove(suPageSection);
                context.SaveChanges();

            }
            return suPageSection;
        }

        public IEnumerable<SuPageSectionModel> GetAllPageSections()
        {
            return context.dbPageSection.AsNoTracking().ToList() ;
        }

        public SuPageSectionModel GetPageSection(int Id)
        {
            return context.dbPageSection.Find(Id);
        }

        public SuPageSectionModel UpdatePageSection(SuPageSectionModel suPageSectionChanges)
        {
            var changedPageSection = context.dbPageSection.Attach(suPageSectionChanges);
            changedPageSection.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suPageSectionChanges;
        }

      
    }
}
