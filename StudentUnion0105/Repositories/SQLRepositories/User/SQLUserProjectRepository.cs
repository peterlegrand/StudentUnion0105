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
            context.DbUserProject.Add(suUserProject);
            context.SaveChanges();
            return suUserProject;
        }

        public SuUserProjectModel DeleteUserProject(int Id)
        {
            var suUserProject = context.DbUserProject.Find(Id);
            if (suUserProject != null)
            {
                context.DbUserProject.Remove(suUserProject);
                context.SaveChanges();

            }
            return suUserProject;
        }

        public IEnumerable<SuUserProjectModel> GetAllUserProjects()
        {
            return context.DbUserProject;
        }

        public SuUserProjectModel GetUserProject(int Id)
        {
            return context.DbUserProject.Find(Id);
        }

        public SuUserProjectModel UpdateUserProject(SuUserProjectModel suUserProjectChanges)
        {
            var suUserProject = context.DbUserProject.Attach(suUserProjectChanges);
            suUserProject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserProjectChanges;
        }
    }
}
