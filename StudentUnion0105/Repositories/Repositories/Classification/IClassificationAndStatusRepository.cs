using StudentUnion0105.Models;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories.Repositories
{
    public interface IClassificationAndStatusRepository
    {
        IEnumerable<SuObjectVM> GetAllClassifications();
        IEnumerable<SuClassificationStatusModel> GetAllStatus();
    }
}
