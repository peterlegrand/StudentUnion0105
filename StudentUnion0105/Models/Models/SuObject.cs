using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuObject
    {

        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string  Status { get; set; }
        public int Int1 { get; set; }
        public int Int2 { get; set; }
        public int? IntNull1 { get; set; }
        public int? IntNull2 { get; set; }
        public bool Bool1 { get; set; }
        public bool Bool2 { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
    }

}
