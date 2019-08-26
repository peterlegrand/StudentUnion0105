﻿using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationVMRepository : IClassificationVMRepository
    {
        private readonly SuDbContext context;

        public SQLClassificationVMRepository( SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuClassificationLanguageModel> GetAllClassificationLanguages()
        {
            return context.dbClassificationLanguage;
        }

        public IEnumerable<SuClassificationModel> GetAllClassifications()
        {
            return context.dbClassification;
        }
    }
}
