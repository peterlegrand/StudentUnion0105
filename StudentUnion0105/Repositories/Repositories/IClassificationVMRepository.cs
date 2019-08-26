using StudentUnion0105.Models;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationVMRepository
    {
        IEnumerable<SuClassificationModel> GetAllClassifications();
        IEnumerable<SuClassificationLanguageModel> GetAllClassificationLanguages();


    }
}
