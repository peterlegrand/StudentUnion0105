using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuFrontPageViewGetModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SecurityLevel { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public string StatusName { get; set; }
        public string TypeName { get; set; }
        public string OrganizationName { get; set; }

    }
}
