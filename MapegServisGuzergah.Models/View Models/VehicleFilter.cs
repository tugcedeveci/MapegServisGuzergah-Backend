using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.View_Models
{
    public class VehicleFilter : DTParameters
    {
        public string? Plate { get; set; }
        public long VehicleId { get; set; }
    }
}
