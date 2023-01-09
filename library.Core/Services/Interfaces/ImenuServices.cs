using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.Core.DTOs.menu;

namespace library.Core.Services.Interfaces
{
    public interface ImenuServices:IDisposable
    {
        Task<List<menuDTOS>> getAllMenuItem(long menuId = 0);
    }
}
