using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuClassificationEditGetModel
    {
        public int Id { get; set; }
        public int ClassificationStatusId { get; set; }
        public int DefaultClassificationPageId { get; set; }
        public bool HasDropDown { get; set; }
        public int DropDownSequence { get; set; }
        public int Lid { get; set; }
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

    public class SuClassificationEditGetWithListModel
    {
        public SuClassificationEditGetModel Classification { get; set; }
        public List<SelectListItem> StatusList { get; set; }

    }
    public class SuClassificationDeleteGetModel
    {
        [Key]
        public int OId { get; set; }
        public string StatusName { get; set; }
        public bool HasDropDown { get; set; }
        public int DropDownSequence { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
    }
}
