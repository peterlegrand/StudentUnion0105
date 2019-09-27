using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.IdentityViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
