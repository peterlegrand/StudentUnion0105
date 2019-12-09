using StudentUnion0105.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageLanguageEditGetModel : SuObjectLanguageEditGetModel
    {
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }

    }
}
