﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuOrganizationLanguageModel
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual SuOrganizationModel Organization { get; set; }
        public virtual SuLanguageModel Language { get; set; }
        
    }
}
