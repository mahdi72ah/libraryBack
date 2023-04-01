using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Core.DTOs.menu
{
    public class menuDTOS
    {
        #region properties
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string title { get; set; }
        public string icon { get; set; }
        public string link { get; set; }

        public long?  menu_id { get; set; }
        public long id { get; set; }
        public List<menuDTOS>? child { get; set; }

        #endregion

        #region Enum

        public enum menuResult
        {
            Success,
            Failed
        }

        #endregion
    }
}
