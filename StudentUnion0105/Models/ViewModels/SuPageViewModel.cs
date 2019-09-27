using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuPageViewModel
    {

        public IEnumerable<SuContentModel>[] ContentViews { get; set; }
        public IEnumerable<SuPageSectionsViewModel> PageSections { get; set; }
    }
}
