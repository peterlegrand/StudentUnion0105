using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationLevelVMRepository : IClassificationLevelVMRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationLevelVMRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuClassificationLevelLanguageModel> GetAllClassificationLevelLanguages()
        {
            return context.dbClassificationLevelLanguage;
        }

        public IEnumerable<SuClassificationLevelModel> GetAllClassificationLevels()
        {
            return context.dbClassificationLevel;
        }
    }
}
