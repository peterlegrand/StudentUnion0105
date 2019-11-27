using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

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
            context.DbProject.Add(suProject);
            context.SaveChanges();
            return suProject;
        }

        public SuProjectModel DeleteProject(int Id)
        {
            var suProject = context.DbProject.Find(Id);
            if (suProject != null)
            {
                context.DbProject.Remove(suProject);
                context.SaveChanges();
            }
            return suProject;
        }

        public IEnumerable<SuProjectModel> GetAllProjects()
        {
            return context.DbProject;
        }

        public SuProjectModel GetProject(int Id)
        {
            return context.DbProject.Find(Id);
        }

        public SuProjectModel UpdateProject(SuProjectModel suProjectChanges)
        {
            var changedProject = context.DbProject.Attach(suProjectChanges);
            changedProject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProjectChanges;
        }
    }
}
