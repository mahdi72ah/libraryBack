using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Core.DTOs.menu;
using library.Core.Services.Interfaces;
using libraryBack.Controllers.commanController;

namespace libraryBack.Controllers.menu
{
    public class menuController : siteBaseController
    {
        #region constarctor

        public ImenuServices _MenuServices;

        public menuController(ImenuServices menuServices)
        {
            _MenuServices = menuServices;
        }

        #endregion

        #region getAllMenuItem
        [HttpGet("getAllMenuItem")]
        public async Task<List<menuDTOS>> getAllMenuItem()
        {
            return await _MenuServices.getAllMenuItem();
        }

        #endregion

    }
}
