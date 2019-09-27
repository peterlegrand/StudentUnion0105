using System;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateStepLanguageModel
    {
        public int Id { get; set; }
        public int StepId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
