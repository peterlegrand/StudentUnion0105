namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFlowModel
    {
        public int Id { get; set; }
        public int ProcessTemplateId { get; set; }
        public int ProcessTemplateFromStep { get; set; }
        public int ProcessTemplateToStep { get; set; }
    }
}
