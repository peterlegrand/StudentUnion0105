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
            context.dbUserRelation.Add(suUserRelation);
            context.SaveChanges();
            return suUserRelation;
        }

        public SuUserRelationModel DeleteUserRelation(int Id)
        {
            var suUserRelation = context.dbUserRelation.Find(Id);
            if (suUserRelation != null)
            {
                context.dbUserRelation.Remove(suUserRelation);
                context.SaveChanges();

            }
            return suUserRelation;
        }

        public IEnumerable<SuUserRelationModel> GetAllUserRelations()
        {
            return context.dbUserRelation;
        }

        public SuUserRelationModel GetUserRelation(int Id)
        {
            return context.dbUserRelation.Find(Id);
        }

        public SuUserRelationModel UpdateUserRelation(SuUserRelationModel suUserRelationChanges)
        {
            var suUserRelation = context.dbUserRelation.Attach(suUserRelationChanges);
            suUserRelation.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suUserRelationChanges;
        }
    }
}
