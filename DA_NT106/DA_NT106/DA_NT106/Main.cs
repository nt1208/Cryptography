using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace DA_NT106
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Connected == true)
            {
                Connected = false;
                swSender.Close();
                srReceiver.Close();
                tcpServer.Close();
            }
        }

        private string UserName = "Unknown";
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private TcpClient tcpServer;
        private delegate void UpdateLogCallback(string strMessage);
        private delegate void CloseConnectionCallback(string strReason);
        private Thread thrMessaging;
        private IPAddress ipAddr;
        private bool Connected;



        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_Shown(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sidePanel1_Click(object sender, EventArgs e)
        {

        }

        private void svgImageBox1_Click(object sender, EventArgs e)
        {

        }

        private void xtraUserControl11_Load(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void navigationPane1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void svgImageBox1_Click_1(object sender, EventArgs e)
        {
            if (panelControl2.Visible == false) panelControl2.Visible = true;
            else panelControl2.Visible = false;
        }

        private void svgImageBox5_Click(object sender, EventArgs e)
        {
            panelControl2.Visible = false;
        }
    }
}
