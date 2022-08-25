using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Core.Entity
{
    public class BaseEntity
    {
        public long? UserCreatedId { get; set; }

        public long? UserModifiedId { get; set; }
        
        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        
        public bool? IsActive { get; set; }
    }
}
