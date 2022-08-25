using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.View_Models
{
    public class SelectorOptionModel
    {
        public string text { get; set; }

        public string valueString { get; set; }

        public Guid? value { get; set; }

        public long? valueInt { get; set; }
        public int? isActive { get; set; }
    }
}
