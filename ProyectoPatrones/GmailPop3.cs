﻿using OpenPop.Mime.Header;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoPatrones
{
    public class GmailPop3 : POP3Server, IPop3
    {
        public GmailPop3()
        {
            this.server = new Pop3Client();
            this.host = "pop.gmail.com";
            this.port = 995;
        }

        public GmailPop3(String user, String pass)
        {
            this.server = new Pop3Client();
            this.host = "pop.gmail.com";
            this.port = 995;
            this.User = user;
            this.Password = pass; 
        }
    
        public bool conectar()
        {
            try
            {
                this.server.Connect(this.host, this.port, true);
                this.server.Authenticate(this.User, this.Password, AuthenticationMethod.UsernameAndPassword);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public override void Credential(String user, String pass)
        {
            this.User = user;
            this.Password = pass;
        }

        public override bool Disconect()
        {
            return true;
        }

        public  Dictionary<int, MyHeaders> getInbox(int max)
        {
            Dictionary<int, MyHeaders> result = new Dictionary<int, MyHeaders>();

            max = this.server.GetMessageCount() - (max * 10);
            int min = max - 10;
            if (min < 1)
            {
                min = 1;
            }
            MyHeaders temp;
            MessageHeader headers;
            for (int i = max; i >= min; i--)
            {
                headers = server.GetMessageHeaders(i);
                temp = new MyHeaders(headers.From.DisplayName, headers.Subject, headers.Date);
                result.Add(i, temp);

            }

            return result;
        }
        public int countMesj()
        {
            return this.server.GetMessageCount();
        }


        public OpenPop.Mime.Message getmsj(int a)
        {
            return this.server.GetMessage(a);
        }
    }
}
