using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.DataLayer.Entities.common;

namespace library.DataLayer.Entities.menu
{
    public class menu : BaseEntities
    {
        #region properties

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string title { get; set; }

        public string idx { get; set; }
        public long?  menu_id { get; set; }

        #endregion

        #region Relations
        [ForeignKey("menu_id")]
        public menu Menu { get; set; }

        #endregion
    }
}
