using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace xiamigrabber
{
    public partial class error : Form
    {
        String s;
        public error(String sl)
        {
            InitializeComponent();
            s = sl;
        }

        private void send_Click(object sender, EventArgs e)
        {
            
            MailMessage msg = new MailMessage();
            msg.To.Add("xgbugs@yjcgators.com");
            msg.From = new MailAddress("xgbugs@yjcgators.com");
            msg.Subject = "Bug Report ("+email.Text+")";
            msg.Body = s + System.Environment.NewLine + comment.Text;

            NetworkCredential cred = new NetworkCredential("xgbugs@yjcgators.com", "f1265361");
            SmtpClient client = new SmtpClient("yjcgators.com", 587);
            client.Credentials = cred;
            client.EnableSsl = false;
            client.Send(msg);
            this.Close();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
