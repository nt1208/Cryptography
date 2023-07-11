using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_NT106
{
    public partial class Form_Register : DevExpress.XtraEditors.XtraForm
    {
        public Form_Register()
        {
            InitializeComponent();
        }

        private void Form_Register_Load(object sender, EventArgs e)
        {

        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_UserName.Text))
            {
                MessageBox.Show(@"User name không được để trống", @"System massage");
                return;
            }
            if (string.IsNullOrEmpty(txt_Pass.Text))
            {
                MessageBox.Show(@"Password không được để trống", @"System massage");
                return;
            }
            if (string.IsNullOrEmpty(txt_Confirm.Text))
            {
                MessageBox.Show(@"Confirm Password không được để trống", @"System massage");
                return;
            }
            if(txt_Confirm.Text != txt_Pass.Text)
            {
                MessageBox.Show(@"Confirm Password không khớp", @"System massage");
                return;
            }
            TcpClient client = new TcpClient();

            // Define the server's IP address and port number
            string serverIP = "127.0.0.1";
            int port = 9999;

            // Connect to the server
            client.Connect(serverIP, port);

            // Get the network stream
            NetworkStream stream = client.GetStream();

            // Receive data from the server
            byte[] buffer = new byte[1024];
            int bytes = stream.Read(buffer, 0, buffer.Length);
            bytes = stream.Read(buffer, 0, buffer.Length); // nhan chuoi sign up
            //Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytes)); // signup

            // Gui yeu cau register cho server
            byte[] byte_op = Encoding.UTF8.GetBytes("2"); // error here
            stream.Write(byte_op, 0, byte_op.Length); // gui option qua cho server

            // Get the user's ID and password
            //Console.Write("\nEnter Userid : ");
            string uid = txt_UserName.Text;
            byte[] byte_uid = Encoding.UTF8.GetBytes(uid);
            stream.Write(byte_uid, 0, byte_uid.Length); // gui  username cho server


            //Console.Write("Enter Password : ");
            string pw = txt_Pass.Text;

            // Hash the password using SHA-1
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pw));
            string hex = BitConverter.ToString(hash).Replace("-", "");
            BigInteger hsh = BigInteger.Parse(hex, System.Globalization.NumberStyles.HexNumber);

            BigInteger bigInteger_x = hsh % 10;
            int x = (int) bigInteger_x;
            int y = (int)Math.Pow(2, x); // g0 = 5
            byte[] byte_y = Encoding.UTF8.GetBytes(y.ToString());
            stream.Write(byte_y, 0, byte_y.Length); // gui y cho server
            Console.WriteLine(byte_y);

           /* bytes = stream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytes));*/
            client.Close();
        }
    }
}