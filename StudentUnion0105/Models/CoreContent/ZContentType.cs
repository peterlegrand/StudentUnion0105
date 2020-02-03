using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuContentTypeDeleteGetModel
    {
        public int Id { get; set; }
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
    public class SuContentTypeEditGetModel
    {
        public int Id { get; set; }
        public int Lid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
    public class SuContentTypeClassificationIndexGetModel
    {
        public int Id { get; set; }
        public int ContentTypeId { get; set; }
        public int ClassificationId { get; set; }
        public string StatusName { get; set; }
        [Required]
        public string ClassificationName { get; set; }
    }
    public class SuContentTypeClassificationEditGetModel
    {
        public int Id { get; set; }
        public int ContentTypeId { get; set; }
        public int ClassificationId { get; set; }
        public int StatusId { get; set; }
        [Required]
        public string ClassificationName { get; set; }
    }
    public class SuContentTypeClassificationEditGetStatusListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class SuContentTypeClassificationEditGetModelWithListModel
    {

        public SuContentTypeClassificationEditGetModel Classification { get; set; }
        public List<SelectListItem> StatusList { get; set; }

    }
    public class SuContentTypeGroupEditGetModel
    {
        public int Id { get; set; }
        public int Lid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }


    }

    public class ContentCreate1GetContentTypeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ContentCreate1GetContentType> Types { get; set; }
    }
    public class ContentCreate1GetContentType
    {
        public int Id { get; set; }
        public string name { get; set; }

    }

}
