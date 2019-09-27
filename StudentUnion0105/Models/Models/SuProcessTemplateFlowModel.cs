namespace StudentUnion0105.Models.Models
{
    public class SuProcessTemplateFlowModel
    {
        public int Id { get; set; }
        public int ProcessTemplateId { get; set; }
        public int ProcessTemplateFromStepId { get; set; }
        public int ProcessTemplateToStepId { get; set; }
    }
}
