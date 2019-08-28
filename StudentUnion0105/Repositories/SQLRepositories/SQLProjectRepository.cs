using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProjectRepository : IProjectRepository
    {
        private readonly SuDbContext context;

        public SQLProjectRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProjectModel AddProject(SuProjectModel suProject)
        {
            context.dbProject.Add(suProject);
            context.SaveChanges();
            return suProject;
        }

        public SuProjectModel DeleteProject(int Id)
        {
            var suProject = context.dbProject.Find(Id);
            if (suProject != null)
            {
                context.dbProject.Remove(suProject);
                context.SaveChanges();
            }
            return suProject;
        }

        public IEnumerable<SuProjectModel> GetAllProjects()
        {
            return context.dbProject;
        }

        public SuProjectModel GetProject(int Id)
        {
            return context.dbProject.Find(Id);
        }

        public SuProjectModel UpdateProject(SuProjectModel suProjectChanges)
        {
            var changedProject = context.dbProject.Attach(suProjectChanges);
            changedProject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProjectChanges;
        }
    }
}
