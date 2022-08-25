using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.View_Models
{
    public class StationFilter : DTParameters
    {
        public string Name { get; set; }
        public long StationId { get; set; }
    }
}
