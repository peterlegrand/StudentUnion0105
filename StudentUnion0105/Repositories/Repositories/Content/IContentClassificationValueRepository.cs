using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IContentClassificationValueRepository
    {
        SuContentClassificationValueModel GetContentClassificationValue(int Id);
        IEnumerable<SuContentClassificationValueModel> GetAllClassifcationClassificationValues();
        SuContentClassificationValueModel AddContentClassificationValue(SuContentClassificationValueModel suContentClassificationValue);
        SuContentClassificationValueModel UpdateContentClassificationValue(SuContentClassificationValueModel suContentClassificationValueChanges);
        SuContentClassificationValueModel DeleteContentClassificationValue(int Id);
    }
}
