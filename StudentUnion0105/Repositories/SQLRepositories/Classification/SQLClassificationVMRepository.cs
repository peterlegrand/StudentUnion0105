using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationVMRepository : IClassificationVMRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationVMRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuClassificationLanguageModel> GetAllClassificationLanguages()
        {
            return context.DbClassificationLanguage;
        }

        public IEnumerable<SuClassificationModel> GetAllClassifications()
        {
            return context.DbClassification;
        }
    }
}
