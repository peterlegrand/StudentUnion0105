using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuTableNameModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public string StatusFieldName { get; set; }
    }
}
