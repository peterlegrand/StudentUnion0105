using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IOrganizationStatusRepository
    {
        SuOrganizationStatusModel GetSuOrganizationStatus(int Id);
        IEnumerable<SuOrganizationStatusModel> GetAllOrganizationStatus();
    }
}
