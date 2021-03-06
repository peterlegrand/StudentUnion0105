﻿using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationRepository
    {
        SuClassificationModel GetClassification(int Id);
        IEnumerable<SuClassificationModel> GetAllClassifcations();
        SuClassificationModel AddClassification(SuClassificationModel suClassification);
        SuClassificationModel UpdateClassification(SuClassificationModel suClassificationChanges);
        SuClassificationModel DeleteClassification(int Id);
    }
}
