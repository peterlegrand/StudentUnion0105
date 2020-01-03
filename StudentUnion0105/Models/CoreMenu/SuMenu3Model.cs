using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuMenu3IndexGetModel
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MouseOver { get; set; }
    }
    public class SuMenu3EditGetModel
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public int ClassificationId { get; set; }
        public int FeatureId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int DestinationId { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string MenuName { get; set; }
        public string MouseOver { get; set; }

    }
    public class SuMenu3EditGetWithListModel
    {
        public SuMenu3EditGetModel Menu2 { get; set; }
        public List<SelectListItem> ClassificationList { get; set; }
        public List<SelectListItem> MenuTypeList { get; set; }
    }
    public class SuMenu3DeleteGetModel
    {
        [Key]
        public int OId { get; set; }
        public string TypeName { get; set; }
        public string ClassificationName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int FeatureId { get; set; }
        public int DestinationId { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string MenuName { get; set; }
        public string MouseOver { get; set; }
        public string LanguageName { get; set; }

    }


}
