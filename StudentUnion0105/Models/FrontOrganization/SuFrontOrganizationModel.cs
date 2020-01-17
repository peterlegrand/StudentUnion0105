using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontOrganizationMyFrontOrganizationGetModel
    {
        [Key]
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string UserOrganizationTypeName { get; set; }
    }
}
