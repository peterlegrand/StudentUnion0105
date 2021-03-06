﻿using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLClaimRepository : IClaimRepository
    {
        private readonly SuDbContext context;

        public SQLClaimRepository(SuDbContext suContext)
        {
            this.context = suContext;
        }

        public IEnumerable<SuClaim> GetAllClaims()
        {
            return context.DbClaim;
        }

    }
}
