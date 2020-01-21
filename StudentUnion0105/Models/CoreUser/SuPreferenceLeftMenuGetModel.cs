using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPreferenceLeftMenuGetModel
    {
        public int Id { get; set; }
        public string MainController { get; set; }
        public string MainAction { get; set; }
        public string AddController { get; set; }
        public string AddAction { get; set; }
        public bool HasMenu { get; set; }
        public bool HasAdd { get; set; }
        public bool HasSearch { get; set; }
        public bool HasAdvancedSearch { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainName { get; set; }
        public string MainMouseOver { get; set; }
        public string AddName { get; set; }
        public string AddMouseOver { get; set; }
        public bool MenuShow { get; set; }
        public bool MenuAddShow { get; set; }
        public bool SearchShow { get; set; }
        public bool AdvancedSearchShow { get; set; }
        public string MenuName { get; set; }
        public string MenuURL { get; set; }
        public int Sequence { get; set; }
    }
    public class SuPreferenceLeftMenuGetAvailableMenusModel
    {
        public int Id { get; set; }
        public string MainController { get; set; }
        public string MainAction { get; set; }
        public string AddController { get; set; }
        public string AddAction { get; set; }
        public bool HasMenu { get; set; }
        public bool HasAdd { get; set; }
        public bool HasSearch { get; set; }
        public bool HasAdvancedSearch { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainName { get; set; }
        public string MainMouseOver { get; set; }
        public string AddName { get; set; }
        public string AddMouseOver { get; set; }
    }

    public class SuPreferenceLeftMenuGetBothMenusModel
    {
        public List<SuPreferenceLeftMenuGetModel> CurrentMenus { get; set; }
        public List<SuPreferenceLeftMenuGetAvailableMenusModel> AvailableMenus { get; set; }
    }

}
