using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProjectLanguageRepository
    {
        SuProjectLanguageModel GetProjectLanguage(int Id);
        IEnumerable<SuProjectLanguageModel> GetAllProjectLanguages();
        SuProjectLanguageModel AddProjectLanguage(SuProjectLanguageModel suProjectLanguage);
        SuProjectLanguageModel UpdateProjectLanguage(SuProjectLanguageModel suProjectLanguageChanges);
        SuProjectLanguageModel DeleteProjectLanguage(int Id);

    }
}
