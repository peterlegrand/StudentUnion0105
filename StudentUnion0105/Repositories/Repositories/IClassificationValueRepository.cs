using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationValueRepository
    {
        SuClassificationValueModel GetClassificationValue(int Id);
        IEnumerable<SuClassificationValueModel> GetAllClassifcationValues();
        SuClassificationValueModel AddClassificationValue(SuClassificationValueModel suClassificationValue);
        SuClassificationValueModel UpdateClassificationValue(SuClassificationValueModel suClassificationValueChanges);
        SuClassificationValueModel DeleteClassificationValue(int Id);

    }
}
