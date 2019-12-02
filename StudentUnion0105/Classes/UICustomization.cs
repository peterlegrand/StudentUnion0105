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
    public class UICustomization
    {
        private readonly SuDbContext _context;

        public UICustomization(SuDbContext context)
        {
            _context = context;
        }
        public string[] UIArray(string Controller, string Action, int languageId)
        {
            //UI Customization
            SqlParameter[] parameters =
                     {
                    new SqlParameter("@Controller", Controller)
                    , new SqlParameter("@Action", Action)
                    , new SqlParameter("@LanguageId", languageId)

                };
            var CustomizationFromDb = _context.ZdbLayoutTermList.FromSql("UITermLanguageSelect @Controller, @Action, @LanguageID", parameters).ToList();
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

        public LayoutWithAllModel UIArrayLayout(int LanguageId)
        {
            //UI Customization
            SqlParameter[] parameters =
                      {
                    new SqlParameter("@Controller", "_Layout")
                    , new SqlParameter("@Action", "")
                    , new SqlParameter("@LanguageId", LanguageId)

                };
            var CustomizationFromDb = _context.ZdbLayoutTermList.FromSql("UITermLanguageSelect @Controller, @Action, @LanguageID", parameters).ToList();
            int NoOfTerms = CustomizationFromDb.Count();
            String[] CustomTerms = new String[NoOfTerms];
            int i = 0;
            foreach (var x in CustomizationFromDb)
            {
                CustomTerms[i] = x.Name;
                i++;
            }
            LayoutWithAllModel Layout = new LayoutWithAllModel();


            Layout.terms = CustomTerms;
            return Layout;
        }
    }
}
