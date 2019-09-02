using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IPageStatusRepository
    {
        SuPageStatusModel GetSuPageStatus(int Id);
        IEnumerable<SuPageStatusModel> GetAllPageStatus();
    }
}
