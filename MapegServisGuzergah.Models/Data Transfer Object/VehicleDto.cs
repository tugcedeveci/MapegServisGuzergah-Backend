using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.Data_Transfer_Object
{
    public class VehicleDto : BaseDto
    {
        public int VehicleId { get; set; }

        public string? Plate { get; set; }

        public int NumberOfSeats { get; set; }

        public int VoyageId { get; set; }

    }
}
