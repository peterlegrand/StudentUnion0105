using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPreferenceIndexGetModel
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public int DefaultLanguageId { get; set; }
        public int CountryId { get; set; }
    }
}
