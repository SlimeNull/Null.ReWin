using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null.ReWin.UI.Module
{
    public class ConnectionInfo
    {
        public virtual string Address { get; set; }
        public virtual int Port { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Description { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ConnectionInfo info)
            {
                return
                    Address == info.Address &&
                    Username == info.Username &&
                    Password == info.Password &&
                    Description == info.Description &&
                    Port == info.Port;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return (Address, Port, Username, Password, Description).GetHashCode();
        }
    }
}
