using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuUserModel : IdentityUser
    {
        [Display(Name = "Default language")]
        public int DefaultLanguageId { get; set; }
        public int? CountryId { get; set; }
        public int SecurityLevel { get; set; }
        public string ManagerId { get; set; }
    }
}
