using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontUserIndexGetModel
    {
        [Key]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }

    }
    public class SuFrontUserUserDashboardGetModel
    {
        [Key]
        public SuFrontUserIndexGetModel User { get; set; }
        public List<SuObjectIndexGetModel> Projects { get; set; }
        public List<SuObjectIndexGetModel2> Organizations { get; set; }
        public List<SuFrontUserUserDashboardGetRelationModel> Relations { get; set; }

    }

    public class SuFrontUserUserDashboardGetRelationModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

}
