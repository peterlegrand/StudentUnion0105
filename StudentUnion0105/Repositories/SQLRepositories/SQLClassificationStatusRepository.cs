﻿using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClassificationStatusRepository : IClassificationStatusRepository
    {
        private readonly SuDbContext _context;

        public SQLClassificationStatusRepository(SuDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SuClassificationStatusModel> GetAllClassificationStatus()
        {
            return _context.dbClassificationStatus;
            
        }

        public SuClassificationStatusModel GetSuClassificationStatus(int Id)
        {
            return  _context.dbClassificationStatus.Find(Id);
        }
    }
}
