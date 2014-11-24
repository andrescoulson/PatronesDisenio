using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPatrones
{
    public interface IPop3
    {
        bool conectar();
        int countMesj();
        OpenPop.Mime.Message getmsj(int c);
        System.Collections.Generic.Dictionary<int, ProyectoPatrones.MyHeaders> getInbox(int m);
    }
}
