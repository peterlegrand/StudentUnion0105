namespace StudentUnion0105.ViewModels
{
    public class SuObjectInObject
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }

        public virtual SuObjectInObject Children { get; set; }
    }
}
