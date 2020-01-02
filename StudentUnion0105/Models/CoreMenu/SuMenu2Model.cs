using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuMenu2IndexGetModel
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MouseOver { get; set; }
    }
    public class SuMenu2EditGetModel
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public int ClassificationId { get; set; }
        public int FeatureId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int DestinationId { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string MenuName { get; set; }
        public string MouseOver { get; set; }

    }

}
