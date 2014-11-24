using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPatrones
{
    public class MyHeaders
    {

        public String from;
        public String subject;
        public String date;

        public MyHeaders(String From, String Subject, String Date)
        {
            this.from = From;
            this.subject = Subject;
            this.date = Date;
        }
    }
}
