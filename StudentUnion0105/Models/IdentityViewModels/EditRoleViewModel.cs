using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace StudentUnion0105.IdentityViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "Role name is required.")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
