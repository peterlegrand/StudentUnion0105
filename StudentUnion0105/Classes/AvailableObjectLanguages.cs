using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Classes
{
    public class AvailableObjectLanguages
    {
        private readonly SuDbContext _context;

        public AvailableObjectLanguages(SuDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> ReturnFreeLanguages(string ObjectName, SqlParameter parameter)
        {
            var ObjectLanguages = _context.DbStatusList.FromSql(ObjectName + "LanguageCreateGetLanguages @OId", parameter).ToList();
            List<SelectListItem> LanguageList = new List<SelectListItem>();
            foreach (var ObjectLanguage in ObjectLanguages)
            {
                LanguageList.Add(new SelectListItem { Value = ObjectLanguage.Id.ToString(), Text = ObjectLanguage.Name });
            }
            return (LanguageList);
        }
        public List<SelectListItem> ReturnFreeLanguages(string ObjectName, int OId)
        {
            var parameter = new SqlParameter("@OId", OId.ToString());
            var ObjectLanguages = _context.DbStatusList.FromSql(ObjectName + "LanguageCreateGetLanguages @OId", parameter).ToList();
            List<SelectListItem> LanguageList = new List<SelectListItem>();
            foreach (var ObjectLanguage in ObjectLanguages)
            {
                LanguageList.Add(new SelectListItem { Value = ObjectLanguage.Id.ToString(), Text = ObjectLanguage.Name });
            }
            return (LanguageList);
        }

    }
}
