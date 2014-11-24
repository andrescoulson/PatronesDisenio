using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenPop.Pop3;

namespace ProyectoPatrones
{
    public abstract class POP3Server
    {
        protected String host;
        private String password;

        
        protected int port;
        protected Pop3Client server;
        private String user;

        public String User
        {
            get { return user; }
            set { user = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public abstract void Credential(String user, String pass);




        public abstract bool Disconect();
        
            
        
    }
}
