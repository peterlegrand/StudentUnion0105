using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUITermRepository
    {
        SuUITermModel GetTerm(int Id);
        IEnumerable<SuUITermModel> GetAllTerms();


    }
}
