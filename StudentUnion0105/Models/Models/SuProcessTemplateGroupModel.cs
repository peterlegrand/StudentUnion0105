﻿using System;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateGroupModel
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
