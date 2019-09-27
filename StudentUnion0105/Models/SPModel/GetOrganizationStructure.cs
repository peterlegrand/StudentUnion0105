using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.SPModel
{
    public class SuGetOrganizationStructure
    {
        public int ParentId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        [Key]
        public string Path { get; set; }

    }
}
