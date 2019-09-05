using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuClaim
    {
        public int Id { get; set; }
        public string ClaimGroup { get; set; }
        public string Claim { get; set; }
        public string ClaimType { get; set; }
    
    }
}
