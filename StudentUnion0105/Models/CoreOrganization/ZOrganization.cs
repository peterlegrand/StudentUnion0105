using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuOrganizationDeleteGetModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string  Type { get; set; }
        public string  Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }

    }
    public class SuOrganizationEditGetModel
    {
        [Key]
        public int OId { get; set; }
        public string ParentOrganization { get; set; }
        public int OrganizationStatusId { get; set; }
        public int OrganizationTypeId { get; set; }
        public int LId { get; set; }
        public int LanguageId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }


    }

    public class SuOrganizationEditGetWithListModel
    {
        public SuOrganizationEditGetModel Organization { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> TypeList { get; set; }

    }

}
