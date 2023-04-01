using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.Core.DTOs.menu;
using library.Core.Services.Interfaces;
using library.DataLayer.Entities.menu;
using library.DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace library.Core.Services.Implementations
{
    public class menuServices : ImenuServices
    {
        private IGenericRepository<menu> _genericRepositoryMenu;

        #region constractor

        public menuServices(IGenericRepository<menu> genericRepositoryMenu)
        {
            _genericRepositoryMenu = genericRepositoryMenu;
        }

        #endregion

        #region getAllMenuItem


        public async Task<List<menuDTOS>> getAllMenuItem(long menuId=0)
        {
            List<menuDTOS> menuTotal = new List<menuDTOS>();
            List<menuDTOS> menuTotalEnd = new List<menuDTOS>();

            if (menuId == 0)
            {
                menuTotal = await _genericRepositoryMenu.GetEntitiesQuery()
                    .Where(c => !c.IsDelete && c.menu_id==null)
                    .Select(c => new menuDTOS()
                    {
                        id = c.Id,
                        menu_id = c.menu_id,
                        title = c.title,
                        icon = c.icon,
                        link = c.link
                    }).ToListAsync();

            }
            else
            {
                menuTotal = await _genericRepositoryMenu.GetEntitiesQuery()
                    .Where(c => !c.IsDelete && c.menu_id == menuId)
                    .Select(c => new menuDTOS()
                    {
                        id = c.Id,
                        menu_id = c.menu_id,
                        title = c.title,
                        link = c.link
                    }).ToListAsync();
            }


            foreach (var item in menuTotal)
            {
                List<menuDTOS> children = new List<menuDTOS>();
                children  =await getAllMenuItem(item.id);
                if (children != null)
                {
                    item.child = children;
                }

                menuTotalEnd.Add(item);
            }

            return menuTotalEnd;
        }


        #endregion


        #region Dispose

        public void Dispose()
        {
           _genericRepositoryMenu?.Dispose();
        }
        #endregion
    }
}
