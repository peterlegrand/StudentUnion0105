using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuHomeIndexAdminGetLanguagesModel
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
    }
    public class SuHomeIndexAdminGetNoOfRecordsAndPerLanguageModel
    {
        public string TableDescription { get; set; }
        [Key]
        public string LanguageName { get; set; }
        public int NoOfRecords { get; set; }

        [ForeignKey("TableDescription")]
        public virtual SuHomeIndexAdminGetTableNameModel TableNames { get; set; }
    }
    public class SuHomeIndexAdminGetTableNameModel
    {
        public int Id { get; set; }
        [Key]
        public string TableDescription { get; set; }
        public virtual List<SuHomeIndexAdminGetNoOfRecordsAndPerLanguageModel> SetOfNoOfRecords { get; set; }
    }

    public class SuHomeIndexAdminGetModel
    {
        public virtual ICollection<SuHomeIndexAdminGetLanguagesModel> languages  { get; set; }
        public virtual ICollection<SuHomeIndexAdminGetTableNameModel> Tables { get; set; }

}

}
