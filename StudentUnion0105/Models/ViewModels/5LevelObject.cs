using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.ViewModels
{
    public class ObjectsOf5LevelsViewModel
    {
        public IEnumerable<SuObjectVM> SuObject1 { get; set; }

        public IEnumerable<SuObjectVM>  SuObject2 { get; set; }

        public IEnumerable<SuObjectVM> SuObject3 { get; set; }

        public IEnumerable<SuObjectVM> SuObject4 { get; set; }

        public IEnumerable<SuObjectVM> SuObject5 { get; set; }
    }
}