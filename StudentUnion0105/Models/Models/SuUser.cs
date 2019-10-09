using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuUser : IdentityUser
    {
        [Display(Name = "Default language")]
        public int DefaultLangauge { get; set; }
    }
}
