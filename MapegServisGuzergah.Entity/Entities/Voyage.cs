using MapegServisGuzergah.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Entity.Entities
{
    public class Voyage : BaseEntity
    {
        public Voyage()
        {
            //this.Vehicles = new HashSet<Vehicle>();
            //this.VoyageStations = new HashSet<VoyageStations>();
            //this.Users = new HashSet<User>();
        }

        public int VoyageId { get; set; }

        public string? VoyageName { get; set; }

        public int RouteId { get; set; }

        public virtual Route? Route { get; set; }

        public virtual List<VoyageStations>? VoyageStations { get; set; }

        public virtual List<Vehicle>? Vehicles { get; set; }

        public virtual List<User>? Users { get; set; }
    }
}
