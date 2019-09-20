﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateLanguageModel
    {
        public int Id { get; set; }
        public int ProcessTemplateId { get; set; }
        public int LanguageId { get; set; }
        public string ProcessTemplateName { get; set; }
        public string ProcessTemplateDescription { get; set; }
        public string SuProcessTemplateMouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
