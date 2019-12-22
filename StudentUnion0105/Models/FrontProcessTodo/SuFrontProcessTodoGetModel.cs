using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontProcessTodoGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}