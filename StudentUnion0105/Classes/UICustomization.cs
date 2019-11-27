using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Classes
{
    public class UICustomization
    {
        private readonly SuDbContext _context;

        public UICustomization(SuDbContext context)
        {
            _context = context;
        }
        public string[] UIArray(string Controller , string Action,int  languageId )
        {
            //UI Customization
            var CustomizationFromDb = _context.DbStatusList.FromSql($"UITermLanguageSelect @p0, @p1, @P2",
                 parameters: new[] {            Controller, Action, //0
                                        languageId.ToString()
                    }).ToList();
            int NoOfTerms = CustomizationFromDb.Count();
            String[] CustomTerms = new String[NoOfTerms];
            int i = 0;
            foreach (var x in CustomizationFromDb)
            {
                CustomTerms[i] = x.Name;
                i++;
            }
            return CustomTerms;
            //UI Customization
        }
    }
}
