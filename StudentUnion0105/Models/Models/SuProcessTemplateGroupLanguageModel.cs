using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateGroupLanguageModel
    {
        public int Id { get; set; }
        public int ProcessTemplateGroupId { get; set; }
        public int LanguageId { get; set; }
        public string ProcessTemplateGroupName { get; set; }
        public string ProcessTemplateGroupDescription { get; set; }
        public string SuProcessTemplateGroupMouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
