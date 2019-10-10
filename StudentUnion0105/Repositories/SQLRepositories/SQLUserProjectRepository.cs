using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;
namespace StudentUnion0105.SQLRepositories
{
    public class SQLUserProjectRepository : IUserProjectRepository
    {
        private readonly SuDbContext context;

        public SQLUserProjectRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuUserProjectModel AddUserProject(SuUserProjectModel suUserProject)
        {
            context.dbUserProject.Add(suUserProject);
            context.SaveChanges();
            return suUserProject;
        }

        public SuUserProjectModel DeleteUserProject(int Id)
        {
            var suUserProject = context.dbUserProject.Find(Id);
            if (suUserProject != null)
            {
                context.dbUserProject.Remove(suUserProject);
                context.SaveChanges();

            }
            return suUserProject;
        }

        public IEnumerable<SuUserProjectModel> GetAllUserProjects()
        {
            return context.dbUserProject;
        }

        public SuUserProjectModel GetUserProject(int Id)
        {
            return context.dbUserProject.Find(Id);
        }

        public SuUserProjectModel UpdateUserProject(SuUserProjectModel suUserProjectChanges)
        {
            var suUserProject = context.dbUserProject.Attach(suUserProjectChanges);
            suUserProject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserProjectChanges;
        }
    }
}
