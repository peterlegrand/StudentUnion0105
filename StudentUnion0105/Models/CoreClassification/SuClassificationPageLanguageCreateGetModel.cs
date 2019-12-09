using StudentUnion0105.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageLanguageCreateGetModel : SuObjectLanguageCreateGetModel
    {
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }

    }
}
