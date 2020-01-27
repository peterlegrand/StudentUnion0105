using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontPageModel
    {
        [Key]
        public int OId { get; set; }
        public bool ShowTitleName { get; set; }
        public bool ShowTitleDescription { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public virtual ICollection<SuFrontPageSectionModel> FrontPageSections { get; set; }
    }
    public class SuFrontPageMyContentGetModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string StatusName { get; set; }
        public string TypeName { get; set; }
        public string OrganizationName { get; set; }
        public string ProjectName { get; set; }
    }
}
