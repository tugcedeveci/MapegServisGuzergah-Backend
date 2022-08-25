using MapegServisGuzergah.Core.Entity;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Entity.Entities
{
    public class Route : BaseEntity
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public Geometry? Geometry { get; set; }

        public virtual List<Voyage> Voyages { get; set; }
        
    }
}
