﻿using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLPageStatusRepository : IPageStatusRepository
    {
        private readonly SuDbContext context;

        public SQLPageStatusRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuPageStatusModel> GetAllPageStatus()
        {
            return context.DbPageStatus;
        }

        public SuPageStatusModel GetSuPageStatus(int Id)
        {
            return context.DbPageStatus.Find(Id);
        }
    }
}
