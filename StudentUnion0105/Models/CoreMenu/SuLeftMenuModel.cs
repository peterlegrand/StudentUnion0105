using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuLeftMenuModel
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MainController { get; set; }
        public string MainAction { get; set; }
        public string AddController { get; set; }
        public string AddAction { get; set; }
        public bool HasMenu { get; set; }
        public bool HasAdd { get; set; }
        public bool HasSearch { get; set; }
        public bool HasAdvancedSearch { get; set; }
        public string ImageName { get; set; }
        public virtual ICollection<SuLeftMenuLanguageModel> LeftMenuLanguages { get; set; }
        public virtual ICollection<SuLeftMenuUserModel> LeftMenuUser { get; set; }
    }
    public class SuLeftMenuLanguageModel
    {
        public int Id { get; set; }
        public int LeftMenuId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(50)]
        public string MainName { get; set; }
        [MaxLength(50)]
        public string MainMouseOver { get; set; }
        [MaxLength(50)]
        public string AddName { get; set; }
        [MaxLength(50)]
        public string AddMouseOver { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("LeftMenuId")]
        public virtual SuLeftMenuModel LeftMenu { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
    public class SuLeftMenuUserModel
    {
        public int Id { get; set; }
        public int LeftMenuId { get; set; }
        public bool MenuShow { get; set; }
        public bool MenuAddShow { get; set; }
        public bool SearchShow { get; set; }
        public bool AdvancedSearchShow { get; set; }
        public string MenuName { get; set; }
        public string MenuURL { get; set; }
        public int Sequence { get; set; }
        public string UserId { get; set; }

        [ForeignKey("LeftMenuId")]
        public virtual SuLeftMenuModel LeftMenu { get; set; }

    }


}
