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
    public class LeftMenu
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public bool MenuShow { get; set; }
        public bool MenuAddShow { get; set; }
        public bool SearchShow { get; set; }
        public bool AdvancedSearchShow { get; set; }
        public bool HasMenu { get; set; }
        public bool HasAdd { get; set; }
        public bool HasSearch { get; set; }
        public bool HasAdvancedSearch { get; set; }
        public string MainController { get; set; }
        public string MainAction { get; set; }
        public string AddController { get; set; }
        public string AddAction { get; set; }
        public string AddName { get; set; }
        public string ImageName { get; set; }
    }
    public class TopMenu1
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuController { get; set; }
        public string MenuAction { get; set; }
        public int MenuDestinationId { get; set; }
        public string IconCss { get; set; }
    }

    public class TopMenu2
    {
        public int Id { get; set; }
        public int Menu1MenuTypeId { get; set; }
        public int Menu2MenuTypeId { get; set; }
        public string MenuName { get; set; }
        public string MenuController { get; set; }
        public string MenuAction { get; set; }
        public int MenuDestinationId { get; set; }
        public string IconCss { get; set; }
    }

}
