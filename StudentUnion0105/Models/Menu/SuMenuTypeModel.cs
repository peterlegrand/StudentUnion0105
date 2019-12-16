using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuMenuTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SuMenu1Model> Menu1 { get; set; }
        public virtual ICollection<SuMenu2Model> Menu2 { get; set; }
        public virtual ICollection<SuMenu3Model> Menu3 { get; set; }
    }
}
