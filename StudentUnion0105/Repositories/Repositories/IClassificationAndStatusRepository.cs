using StudentUnion0105.Models;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories.Repositories
{
    public interface IClassificationAndStatusRepository
    {
        IEnumerable<SuObjectVM> GetAllClassifications();
        IEnumerable<SuClassificationStatusModel> GetAllStatus();
    }
}
