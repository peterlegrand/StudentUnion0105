using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class Menu1
    {
        public int Id { get; set; }
        public int MenuTypeId { get; set; }
        public int ClassificationId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int DestinationId { get; set; }
        public string MenuName { get; set; }
        public string MouseOver { get; set; }
        public int NoOfMenus2 { get; set; }
        public int NoOfClassifications { get; set; }
    }
    public class Menu2
    {
        public int PId { get; set; }
        public string MenuType { get; set; }
        public int Id { get; set; }
        public string MenuName { get; set; }
        public int NoOfMenus3 { get; set; }
        public int NoOfClassifications { get; set; }
    }
    public class Menu3
    {
        public int PId { get; set; }
        public string MenuType { get; set; }
        public int Id { get; set; }
        public string MenuName { get; set; }
    }

    public class FullMenu
    {
        public List<Menu1> Menu1 { get; set; }
        public List<Menu2> Menu2 { get; set; }
        public List<Menu3> Menu3 { get; set; }


    }
}
