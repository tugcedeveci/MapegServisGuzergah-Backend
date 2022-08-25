using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.Data_Transfer_Object
{
    public class VoyageDto : BaseDto
    {
        public int VoyageId { get; set; }

        public int RouteId { get; set; }


        public string? VoyageName { get; set; }
    }
}
