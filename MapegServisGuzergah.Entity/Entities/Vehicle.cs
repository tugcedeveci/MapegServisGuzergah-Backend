using MapegServisGuzergah.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Entity.Entities
{
    public class Vehicle : BaseEntity
    {   
        public int VehicleId { get; set; }

        public string? Plate { get; set; }
        
        public int NumberOfSeats { get; set; }

        public int VoyageId { get; set; }

        public virtual Voyage? Voyage { get; set; }
     
    }
}
