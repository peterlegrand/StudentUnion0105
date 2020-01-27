using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuFrontContentModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
//        public int SecurityLevel { get; set; }
//        public int ContentTypeId { get; set; }
//        public DateTime CreateDate { get; set; }
        [ForeignKey("PId")]
        public virtual SuFrontPageSectionModel FrontPageSection { get; set; }
    }
}
