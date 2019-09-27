using Microsoft.AspNetCore.Identity;

namespace StudentUnion0105.Models
{
    public class SuUser : IdentityUser
    {
        public int DefaultLangauge { get; set; }
    }
}
