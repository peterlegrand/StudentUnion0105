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

        public async Task<List<MenuItem>> TopMenu(int LanguageId )
        {

            var parameter = new SqlParameter("@LanguageId", LanguageId);

            var TopMenu1List = await _context.ZdbTopMenu1.FromSql("PartialTopMenu1 @LanguageId", parameter).ToListAsync();


            List<MenuItem> menuItem1List = new List<MenuItem>();
            foreach (var TopMenu1 in TopMenu1List)
            {
                menuItem1List.Add(new MenuItem
                {
                    Text = TopMenu1.MenuName,
                    IconCss = TopMenu1.IconCss,
                    Url = TopMenu1.MenuController,
                    //PETER CONTEXT
                  //  Items = new List<MenuItem>(Menu2(TopMenu1.Id, LanguageId))
            });



            }
            return menuItem1List;
        }
        private async Task<List<MenuItem>> Menu2(int Id, int LanguageId)
        {
            SqlParameter[] parameters =
               {
                    new SqlParameter("@LanguageId", LanguageId)
                    , new SqlParameter("@Id", Id)
                };

            var TopMenu2List = await _context.ZdbTopMenu2.FromSql("PartialTopMenu2 @LanguageId, @Id", parameters).ToListAsync();


            List<MenuItem> menuItem2List = new List<MenuItem>();
            foreach (var TopMenu2 in TopMenu2List)
            {
                menuItem2List.Add(new MenuItem
                {
                    Text = TopMenu2.MenuName,
                    IconCss = TopMenu2.IconCss,
                    Url = TopMenu2.MenuController,
//                    Items = new List<MenuItem>(Menu3(TopMenu2.Id, LanguageId))

                });


            }

            return menuItem2List;
        }
        private List<MenuItem> Menu3(int Id, int LanguageId)
        {
            SqlParameter[] parameters =
               {
                    new SqlParameter("@LanguageId", LanguageId)
                    , new SqlParameter("@Id", Id)
                };

            var TopMenu2List = _context.ZdbTopMenu2.FromSql("PartialTopMenu2 @LanguageId, @Id", parameters).ToList();


            List<MenuItem> menuItem2List = new List<MenuItem>();
            foreach (var TopMenu2 in TopMenu2List)
            {
                menuItem2List.Add(new MenuItem
                {
                    Text = TopMenu2.MenuName,
                    IconCss = TopMenu2.IconCss,
                    Url = TopMenu2.MenuController
                });


            }

            return menuItem2List;
        }
    }
}
