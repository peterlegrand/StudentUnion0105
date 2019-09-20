﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuContentClassificationValueModel
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int ClassificationValueId { get; set; }
        [ForeignKey("ClassificationValueId")]
        public virtual SuClassificationValueModel ClassificationValue { get; set; }
        [ForeignKey("ContentId")]
        public virtual SuContentModel Content { get; set; }

    }
}
