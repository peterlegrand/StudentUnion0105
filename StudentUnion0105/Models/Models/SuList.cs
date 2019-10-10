﻿using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuStatusList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SuTypeList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SuSecurityLevelList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SuLanguageList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SuCountryList
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
    }
    public class SuValueList
    {
        [Key]
        public int ClassificationValueId { get; set; }
        public string ClassificationValueName { get; set; }
    }
}
