using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuLanguageModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string LanguageName { get; set; }

        public virtual ICollection<SuClassificationLanguageModel> ClassificationLanguages { get; set; }
        public virtual ICollection<SuClassificationLevelLanguageModel> ClassificationLevelLanguages { get; set; }
        public virtual ICollection<SuClassificationValueLanguageModel> ClassificationValueLanguages { get; set; }
        public virtual ICollection<SuContentTypeLanguageModel> ContentTypeLanguages { get; set; }
        public virtual ICollection<SuOrganizationLanguageModel> OrganizationLanguages { get; set; }
        public virtual ICollection<SuOrganizationTypeLanguageModel> OrganizationTypeLanguages { get; set; }
        public virtual ICollection<SuProjectLanguageModel> ProjectLanguages { get; set; }

    }
}
