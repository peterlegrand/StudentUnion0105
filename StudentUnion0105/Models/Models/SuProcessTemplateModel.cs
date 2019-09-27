﻿using System;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateModel
    {
        public int Id { get; set; }
        public int ProcessTemplateGroupId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
