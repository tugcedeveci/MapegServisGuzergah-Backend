using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.Data_Transfer_Object
{
    public class BaseDto
    {
        public int? UserCreatedId { get; set; }

        public int? UserModifiedId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
