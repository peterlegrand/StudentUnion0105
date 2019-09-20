using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuPageViewModel
    {

        public IEnumerable<SuContentModel>[] ContentViews { get; set; }
        public IEnumerable<SuPageSectionsViewModel> PageSections { get; set; }
    }
}
