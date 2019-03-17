using System;
using System.Collections.Generic;
using System.Text;

namespace TesisBlaMig.Models
{
    public class  DeviceUser
    {
        public int UsuarioID { get; set; }
        public string NickNamre { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
