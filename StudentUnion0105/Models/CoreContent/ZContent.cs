using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuContentCreate2GetClassificationsModel
    {
        public int Id { get; set; }
    }

    public class SuContentEditGetContentModel
    {
        public int Id { get; set; }
        public int ContentTypeId { get; set; }
        public int ContentStatusId { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SecurityLevel { get; set; }
        public int OrganizationId { get; set; }
        public int ProjectId { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }

    }

    public class SuContentEditGetClassificationValuesModel
    {
        public int Id { get; set; }
        [Key]
        public int ClassificationId { get; set; }
        public int ValueId { get; set; }
    }

    public class SuContentEditGetAllLists
    {
        public SuContentEditGetContentModel Content { get; set; }
        public IEnumerable<SelectListItem> ContentType { get; set; }
        public IEnumerable<SelectListItem> ContentStatus { get; set; }
        public IEnumerable<SelectListItem> Organization { get; set; }
        public IEnumerable<SelectListItem> Project { get; set; }
        public IEnumerable<SelectListItem> SecurityLevel { get; set; }
        public IEnumerable<SelectListItem> Langauge { get; set; }
        public IEnumerable<SelectListItem>[] Values { get; set; }
        public List<SuContentEditGetClassificationValuesModel> SelectedValues { get; set; }
        public int? NoOfClassifications { get; set; }
    }

}
