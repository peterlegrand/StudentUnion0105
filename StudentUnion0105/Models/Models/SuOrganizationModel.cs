﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuOrganizationModel
    {
        public int Id { get; set; }
        public int ParentOrganizationId { get; set; }
        public int OrganizationStatusId { get; set; }
        public int OrganizationTypeId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual SuOrganizationStatusModel OrganizationStatus { get; set; }
        public virtual SuOrganizationTypeModel OrganizationType { get; set; }
        public virtual ICollection<SuOrganizationLanguageModel> OrganizationLanguages { get; set; }
        
    }
}