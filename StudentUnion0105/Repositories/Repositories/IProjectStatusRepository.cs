using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    interface IProjectStatusRepository
    {
        SuProjectStatusModel GetSuProjectStatus(int Id);
        IEnumerable<SuProjectStatusModel> GetAllProjectStatus();
    }
}
