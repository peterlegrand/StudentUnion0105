using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuTermLanguageCreateGetModel
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Customization { get; set; }        
    }
}
