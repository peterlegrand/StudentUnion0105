﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuUserOrganizationModel
    {
        public int Id { get; set; }
        [Display(Name = "User Id")]
        [MaxLength(450)]
        public string UserId { get; set; }
        [Display(Name = "Organization Id")]
        public int OrganizationId { get; set; }
        [Display(Name = "Type Id")]
        public int TypeId { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("UserId")]
        public virtual SuUserModel  User { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual SuOrganizationModel Organization { get; set; }
        [ForeignKey("TypeId")]
        public virtual SuUserOrganizationTypeModel Type { get; set; }
    }
}
