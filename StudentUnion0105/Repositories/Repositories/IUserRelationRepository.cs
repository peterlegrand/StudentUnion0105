using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUserRelationRepository
    {
        SuUserRelationModel GetUserRelation(int Id);
        IEnumerable<SuUserRelationModel> GetAllUserRelations();
        SuUserRelationModel AddUserRelation(SuUserRelationModel suUserRelation);
        SuUserRelationModel UpdateUserRelation(SuUserRelationModel suUserRelationChanges);
        SuUserRelationModel DeleteUserRelation(int Id);
    }
}
