﻿using StudentUnion0105.SPModel;
using System.Collections.Generic;
using static StudentUnion0105.SPModel.GetProjectStructure;

namespace StudentUnion0105.ViewModels
{
    public class OrgStructureWithDepth
    {
        //public List<SuClassificationStatusModel> Status { get; set; }
        public int MaxLevel { get; set; }
        public List<SuOrganizationIndexGet> OrgStructure { get; set; }

    }
    public class ProjStructureWithDepth
    {
        //public List<SuClassificationStatusModel> Status { get; set; }
        public int MaxLevel { get; set; }
        public List<SuGetProjectStructure> ProjStructure { get; set; }

    }

    public class ValueStructureWithDepth
    {
        //public List<SuClassificationStatusModel> Status { get; set; }
        public int MaxLevel { get; set; }
        public int MaxConfigLevel { get; set; }
        public List<SuClassificationValueIndexGet> ValueStructure { get; set; }

    }


}
