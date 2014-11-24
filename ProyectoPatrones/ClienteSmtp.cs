using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPatrones
{
    public class ClienteSmtp
    {
        POP3Server smtp;

        public ClienteSmtp(POP3Server server)
        {
            smtp = server;
        }
    }
}
