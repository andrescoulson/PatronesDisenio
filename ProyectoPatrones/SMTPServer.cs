using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ProyectoPatrones
{
    public abstract class SMTPServer
    {
        protected NetworkCredential bCredential;
        protected SmtpClient client;
        protected POP3Server server;

        public abstract void enviar(String To, String Subject, String Body, String[] Attach);
        
        
    }
}
