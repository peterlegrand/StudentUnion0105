using StudentUnion0105.Models;
using System.Collections.Generic;

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
