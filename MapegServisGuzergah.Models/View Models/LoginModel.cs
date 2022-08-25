using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.View_Models
{
    public class LoginModel
    {
        public long UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
