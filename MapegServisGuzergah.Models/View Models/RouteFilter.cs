using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.View_Models
{
    public class RouteFilter : DTParameters
    {
        public string Name { get; set; }    
        public long RouteId { get; set; }
    }
}
