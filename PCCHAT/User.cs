using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCHAT
{
    public class User
    {
        public User()
        {

        }
        public User(string USERNAME, string IP, int PORT, ENUMSTATUS STATUS)
        {
            this.USERNAME = USERNAME;
            this.IP = IP;
            this.PORT = PORT;
            this.STATUS = STATUS;
        }
        public enum ENUMSTATUS
        {
            ON=0,
            OFF=1
        }
        public string USERNAME { set; get; }
        public string IP { set; get; }
        public int PORT { set; get; }
        public ENUMSTATUS STATUS { set; get; }
        public bool FLAG { set; get; }
    }
}
