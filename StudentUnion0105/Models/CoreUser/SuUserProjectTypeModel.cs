using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuUserProjectTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SuUserProjectModel> UserProjects { get; set; }
        public virtual ICollection<SuUserProjectTypeLanguageModel> UserProjectTypLanguages { get; set; }

    }
}
