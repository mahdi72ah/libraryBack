﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.Core.DTOs.menu;

namespace library.Core.Services.Interfaces
{
    public interface ImenuServices:IDisposable
    {
        Task<List<menuDTOS>> getAllMenuItem();
        Task<List<menuDTOS>> getMenuItemByMenu_id(long menu_id=0);
    }
}
