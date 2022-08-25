using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.View_Models
{
    public class VoyageFilter : DTParameters
    {
        public string? VoyageName { get; set; }
        public long VoyageId { get; set; }
    }
}
