﻿using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFieldRepository
    {
        SuProcessTemplateFieldModel GetProcessTemplateField(int Id);
        IEnumerable<SuProcessTemplateFieldModel> GetAllProcessTemplateFields();
        SuProcessTemplateFieldModel AddProcessTemplateField(SuProcessTemplateFieldModel suProcessTemplateField);
        SuProcessTemplateFieldModel UpdateProcessTemplateField(SuProcessTemplateFieldModel suProcessTemplateFieldChanges);
        SuProcessTemplateFieldModel DeleteProcessTemplateField(int Id);
    }
}
