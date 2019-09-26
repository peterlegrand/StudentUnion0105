﻿using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateStepLanguageRepository
    {
        SuProcessTemplateStepLanguageModel GetProcessTemplateStepLanguage(int Id);
        IEnumerable<SuProcessTemplateStepLanguageModel> GetAllProcessTemplateStepLanguages();
        SuProcessTemplateStepLanguageModel AddProcessTemplateStepLanguage(SuProcessTemplateStepLanguageModel suProcessTemplateStepLanguage);
        SuProcessTemplateStepLanguageModel UpdateProcessTemplateStepLanguage(SuProcessTemplateStepLanguageModel suProcessTemplateStepLanguageChanges);
        SuProcessTemplateStepLanguageModel DeleteProcessTemplateStepLanguage(int Id);
    }
}
