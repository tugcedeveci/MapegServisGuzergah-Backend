using MapegServisGuzergah.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Entity.Entities
{
    public class VoyageStations : BaseEntity
    {
        public int VoyageStationId { get; set; }

        public int VoyageId { get; set; }

        public int StationId { get; set; } 

        public virtual Voyage Voyage { get; set; }

        public virtual Station Station { get; set; }
     
    }
}
