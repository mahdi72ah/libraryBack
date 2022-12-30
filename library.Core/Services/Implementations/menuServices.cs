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

        public async Task<List<menuDTOS>> getAllMenuItem()
        {
            List<menuDTOS> menuTotal = new List<menuDTOS>();


          menuTotal = await _genericRepositoryMenu.GetEntitiesQuery()
                .Where(c => c.menu_id == null  && !c.IsDelete)
                . Select( c => new menuDTOS()
                {
                  menu_id = c.menu_id,
                  title = c.title,
                  child = _genericRepositoryMenu.GetEntitiesQuery()
                      .Where(p => p.menu_id == c.Id)
                      .Select(p => new menuDTOS()
                      {
                          id = p.Id,
                          title = p.title,
                          menu_id = p.menu_id
                      }).ToList()
                }).ToListAsync();

             return menuTotal;
        }

        public async Task<List<menuDTOS>> getMenuItemByMenu_id(long menu_id=0)
        {
                var child= await  _genericRepositoryMenu.GetEntitiesQuery()
                .Where(p => p.menu_id == menu_id)
                .Select(p=>new menuDTOS()
                {
                    id = p.Id,
                    title = p.title,
                    menu_id = p.menu_id
                }) .ToListAsync();
                return child;
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
