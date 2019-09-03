using StudentUnion0105.SPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.ViewModels
{
    public class OrgStructureWithDepth
    {
            //public List<SuClassificationStatusModel> Status { get; set; }
            public int  MaxLevel { get; set; }
            public List<SuGetOrganizationStructure> OrgStructure { get; set; }

    }
}
