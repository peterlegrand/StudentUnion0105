using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontOrganizationMyOrganizationGetModel
    {
        [Key]
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string UserOrganizationTypeName { get; set; }
    }
    public class SuFrontOrganizationDashboardGetOrganizationModel
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string StatusName { get; set; }
        public string TypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Modifier { get; set; }
        public string ParentName { get; set; }
    }
    public class SuFrontOrganizationDashboardGetContentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentTypeName { get; set; }
        public string ContentStatusName { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
    public class SuFrontOrganizationDashboardGetUsersModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string TypeName { get; set; }
    }

    public class SuFrontOrganizationDashboardGetModel
    {
        public SuFrontOrganizationDashboardGetOrganizationModel Organization { get; set; }
        public List<SuFrontOrganizationDashboardGetContentModel> Content { get; set; }
        public List<SuFrontOrganizationDashboardGetUsersModel> Users { get; set; }
    }
}
