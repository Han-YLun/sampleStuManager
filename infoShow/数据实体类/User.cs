using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoShow.javabean
{
   public class User
    {
        string userName;
        string pwd;

        public User(string userName,string pwd)
        {
            this.userName = userName;
            this.pwd = pwd;
        }

        public User()
        {
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

    }
}
