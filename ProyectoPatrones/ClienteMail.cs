using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPatrones
{
    public class ClienteMail
    {

        IPop3 clientPop;

        public ClienteMail (IPop3 strategy)
        {
            clientPop = strategy;
        }

        public bool conect()
        {
            return clientPop.conectar();
        }

        public Dictionary<int, MyHeaders> GetInbox(int p)
        {
            return clientPop.getInbox(p);
        }
        public int CountMessage()
        {
            return clientPop.countMesj();
        }
        public OpenPop.Mime.Message mesaje(int d)
        {
            return clientPop.getmsj(d);
        }

    }
}
