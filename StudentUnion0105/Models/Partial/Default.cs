using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class Menu1
    {
        public int Id { get; set; }
        public string DestinationURL { get; set; }
        public string MenuName { get; set; }
        public List<Menu2> Menu2 { get; set; }
    }
    public class Menu2
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public string DestinationURL { get; set; }
        public string MenuName { get; set; }
        public List<Menu3> Menu3 { get; set; }
        [ForeignKey("PId")]
        public virtual Menu1 Menu1 { get; set; }
    }
    public class Menu3
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int PPId { get; set; }
        public string DestinationURL { get; set; }
        public string MenuName { get; set; }
        [ForeignKey("PId")]
        public virtual Menu2 Menu2 { get; set; }
    }
}
