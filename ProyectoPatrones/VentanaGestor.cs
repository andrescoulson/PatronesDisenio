using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPatrones
{
    public partial class VentanaGestor : Form
    {
        ClienteMail cliente;
        ClienteSmtp smtp;
        DataTable inbox = new DataTable();
        int Page;
        public VentanaGestor()
        {
            InitializeComponent();
            inbox.Columns.Add("From");
            inbox.Columns.Add("Subject");
            inbox.Columns.Add("Date");
            panelVerCorreo.Visible = false;
        }

        private void fillInbox(int AddOrSub)
        {
            Page = Page + AddOrSub;
            if (Page < 0)
            {
                Page = 0;
            }
            Dictionary<int, MyHeaders> headers = cliente.GetInbox(Page);
            inbox.Rows.Clear();
            foreach (KeyValuePair<int, MyHeaders> entry in headers)
            {
                inbox.Rows.Add(entry.Value.from, entry.Value.subject, entry.Value.date);

            }
            this.dataGridView1.DataSource = inbox;
            this.dataGridView1.AutoResizeColumns();
            this.lblPag.Text = "Página " + (Page + 1);
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            fillInbox(1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fillInbox(-1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int NumMensaje = cliente.CountMessage() - (this.Page * 10 + e.RowIndex);
            OpenPop.Mime.Message mail = cliente.mesaje(NumMensaje);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panelVerCorreo.Visible = true;
            
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            String user = txtemail.Text;
            String pass = txtPass.Text;

            String[] words = user.Split('@');

            if (words[1] == "hotmail.com")
            {
                cliente = new ClienteMail(new HotmailPop3(user, pass));
                smtp = new ClienteSmtp(new HotmailPop3());

            }
            if (words[1] == "yahoo.com")
            {
                cliente = new ClienteMail(new YahooPop3(user, pass));
                smtp = new ClienteSmtp(new YahooPop3());
            }

            if (words[1] == "gmail.com")
            {
                cliente = new ClienteMail(new GmailPop3(words[0], pass));
                smtp = new ClienteSmtp(new GmailPop3());
            }

            if (cliente.conect())
            {
                panelLogin.Visible = false;
                panelVerCorreo.Visible = true;
                fillInbox(0);

            }
        }

      
    }
}
