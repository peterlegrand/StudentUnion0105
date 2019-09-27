using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationStatusRepository
    {
        SuClassificationStatusModel GetSuClassificationStatus(int Id);
        IEnumerable<SuClassificationStatusModel> GetAllClassificationStatus();


    }
}
