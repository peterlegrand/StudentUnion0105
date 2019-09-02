using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SPModel
{
    public class SuGetOrganizationStructure
    {
        [Key]
        public int Id1 { get; set; }
        public string Name1 { get; set; }
        [Key]
        public int Id2 { get; set; }
        public string Name2 { get; set; }
        [Key]
        public int Id3 { get; set; }
        public string Name3 { get; set; }

    }
}
