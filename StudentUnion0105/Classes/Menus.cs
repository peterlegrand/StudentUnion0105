using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.EJ2.Navigations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace StudentUnion0105.Classes
{
    public class Menus
    {
        private readonly SuDbContext _context;

        public Menus(SuDbContext context)
        {
            _context = context;
        }

        public  List<MenuItem> TopMenu(int LanguageId )
        {

            var parameter = new SqlParameter("@LanguageId", LanguageId);

            var TopMenu1List = _context.ZdbTopMenu1.FromSql("PartialTopMenu1 @LanguageId", parameter).ToList();


            List<MenuItem> menuItem1List = new List<MenuItem>();
            foreach (var TopMenu1 in TopMenu1List)
            {
                menuItem1List.Add(new MenuItem
                {
                    Text = TopMenu1.MenuName,
                    IconCss = TopMenu1.IconCss,
                    Url = TopMenu1.MenuController,
                    Items = new List<MenuItem>()
                {
                    new MenuItem { Text= "Open", IconCss= "em-icons e-open", Url= "Home/Open" },
                    new MenuItem { Text= "Save", IconCss= "e-icons e-save", Url= "Home/Save" },
                    new MenuItem { Separator= true },
                    new MenuItem { Text= "Exit", Url= "Home/Exit" }
                }
                });



            }
            return menuItem1List;
        }

    }
}
