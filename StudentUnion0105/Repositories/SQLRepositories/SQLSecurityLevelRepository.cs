﻿using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLSecurityLevelRepository : ISecurityLevelRepository
    {
        private readonly SuDbContext context;

        public SQLSecurityLevelRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuSecurityLevelModel> GetAllSecurityLevel()
        {
            return context.dbSecurityLevel;
            
        }

        public SuSecurityLevelModel GetSuSecurityLevel(int Id)
        {
            return  context.dbSecurityLevel.Find(Id);
        }
    }
}
