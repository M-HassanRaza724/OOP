using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Tasks
{
    public class MUser
    {
        public string email;
        public string username;
        public string password;
        public int role;

        public MUser(string username, string email, string password ,int role = 2)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.role = role;
        }


    } 
}
