﻿using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    interface IClassificationValueLanguageRepository
    {
        SuClassificationValueLanguageModel GetClassificationValueLanguage(int Id);
        IEnumerable<SuClassificationValueLanguageModel> GetAllClassificationValueLanguages();
        SuClassificationValueLanguageModel AddClassificationValueLanguage(SuClassificationValueLanguageModel suClassificationValueLanguage);
        SuClassificationValueLanguageModel UpdateClassificationValueLanguage(SuClassificationValueLanguageModel suClassificationValueLanguageChanges);
        SuClassificationValueLanguageModel DeleteClassificationValueLanguage(int Id);

    }
}
