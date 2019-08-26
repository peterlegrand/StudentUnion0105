using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuUser : IdentityUser
    {
        public int DefaultLangauge { get; set; }
    }
}
