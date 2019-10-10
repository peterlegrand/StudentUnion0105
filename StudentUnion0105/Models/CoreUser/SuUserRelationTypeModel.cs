using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuUserRelationTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SuUserRelationModel> UserRelations { get; set; }
        public virtual ICollection<SuUserRelationTypeLanguageModel> UserRelationTypLanguages { get; set; }

    }
}
