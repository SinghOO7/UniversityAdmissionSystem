using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEntity
{
    public class Users
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string ProgramName { get; set; }
        public string Role { get; set; }

        public Users() { }
        public Users(string loginid,string password,string progname,string role)
        {
            this.LoginId = loginid;
            this.Password = password;
            this.ProgramName = progname;
            this.Role = role;
        }
    }
}
