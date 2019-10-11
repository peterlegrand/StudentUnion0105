using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUserRelationTypeRepository
    {
        SuUserRelationTypeModel GetUserRelationType(int Id);
        IEnumerable<SuUserRelationTypeModel> GetAllUserRelationTypes();

    }
}
