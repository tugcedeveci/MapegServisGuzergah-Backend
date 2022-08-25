using MapegServisGuzergah.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Entity.Entities
{
    public class Station : BaseEntity
    {
        public int StationId { get; set; }

        public string? StationName { get; set; }

        public int LocationId { get; set; }

        public virtual Location? Location { get; set; }

        public virtual List<VoyageStations>? VoyageStations { get; set; }
    }
}
