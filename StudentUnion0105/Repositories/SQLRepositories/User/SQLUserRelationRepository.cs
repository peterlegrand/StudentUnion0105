using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLUserRelationRepository : IUserRelationRepository
    {
        private readonly SuDbContext context;

        public SQLUserRelationRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuUserRelationModel AddUserRelation(SuUserRelationModel suUserRelation)
        {
            context.DbUserRelation.Add(suUserRelation);
            context.SaveChanges();
            return suUserRelation;
        }

        public SuUserRelationModel DeleteUserRelation(int Id)
        {
            var suUserRelation = context.DbUserRelation.Find(Id);
            if (suUserRelation != null)
            {
                context.DbUserRelation.Remove(suUserRelation);
                context.SaveChanges();

            }
            return suUserRelation;
        }

        public IEnumerable<SuUserRelationModel> GetAllUserRelations()
        {
            return context.DbUserRelation;
        }

        public SuUserRelationModel GetUserRelation(int Id)
        {
            return context.DbUserRelation.Find(Id);
        }

        public SuUserRelationModel UpdateUserRelation(SuUserRelationModel suUserRelationChanges)
        {
            var suUserRelation = context.DbUserRelation.Attach(suUserRelationChanges);
            suUserRelation.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserRelationChanges;
        }
    }
}
