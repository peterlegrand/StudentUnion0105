using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.SPModel
{
    public class SuGetClassificationValueStructure
    {
        public int ParentId { get; set; }
        public int Id { get; set; }
        public int 	ClassificationId  { get; set; }
        public string ClassificationValueName { get; set; }
        public int Level { get; set; }
        [Key]
        public string Path { get; set; }

    }
}
