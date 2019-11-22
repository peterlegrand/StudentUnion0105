using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{   
    public class SuClassificationValueEditGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int LId { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string DropDownName { get; set; }
        public string HeaderName { get; set; }
        public string HeaderDescription { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string TopicName { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DateLevel { get; set; }
        public bool InDropDown { get; set; }

    }
}
