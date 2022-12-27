using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.DataLayer.Entities.common
{
    public class BaseEntities
    {
        [Key]
        public long Id { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
