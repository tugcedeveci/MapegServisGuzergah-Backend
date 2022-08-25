using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.View_Models
{
    public class ForgotPassword
    {
        public string Mail { get; set; }

        public long UserId { get; set; }

        public string Password { get; set; }
    }
}
