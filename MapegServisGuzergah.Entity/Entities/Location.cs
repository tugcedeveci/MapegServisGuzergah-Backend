using MapegServisGuzergah.Core.Entity;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Entity.Entities
{
    public class Location : BaseEntity
    {
        public int LocationId { get; set; }

        public int? CountyId { get; set; }

        public Geometry? Geometry { get; set; }

        public virtual Station? Station { get; set; }
    }
}
