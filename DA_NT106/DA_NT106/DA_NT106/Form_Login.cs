using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_NT106
{
    public partial class Form_Login : DevExpress.XtraEditors.XtraForm
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
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
            /*Console.Write("IP address: ");
            string ipAddress = Console.ReadLine();
            Client client = new Client();
            client.Connect(ipAddress);*/

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
            int bytes;
            /*int bytes = stream.Read(buffer, 0, buffer.Length); // nhan chuoi "n1->Login\n2->NewUser"
            string nofi1 = Encoding.UTF8.GetString(buffer);
            Console.WriteLine(nofi1);*/
            //Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytes)); 

            // Get the user's option
            //Console.Write("\nEnter your option : ");
            //string op = Console.ReadLine();
            byte[] byte_op = Encoding.UTF8.GetBytes("1"); // error here
            stream.Write(byte_op, 0, byte_op.Length); // gui option qua cho server

            // Convert the option to an integer
            //int opInt = int.Parse(op);

            /* if (opInt == 1)
             {*/
            /* bytes = stream.Read(buffer, 0, buffer.Length); // nhan chuoi "Login Procedure initiating"
                                                            // Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytes));
             string nofi2 = Encoding.UTF8.GetString(buffer);
             Console.WriteLine(nofi2);*/

            // Receive a random number from the server
            bytes = stream.Read(buffer, 0, buffer.Length);
            int a = int.Parse(Encoding.UTF8.GetString(buffer, 0, bytes));
            Console.WriteLine("Random number a: " + a);

            Random rand = new Random();
            int r = rand.Next(1, 11); // rx

            // Get the user's ID and password
            //Console.Write("\nEnter Userid : ");
            string uid = txt_UserName.Text;
            byte[] byte_uid = Encoding.UTF8.GetBytes(uid);
            stream.Write(byte_uid, 0, byte_uid.Length);

            //Console.Write("Enter Password : ");
            string pw = txt_Pass.Text;
            byte[] byte_pw = Encoding.UTF8.GetBytes(pw);

            // Hash the password using SHA-1
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(byte_pw);
            string hex = BitConverter.ToString(hash).Replace("-", "");
            Console.WriteLine(hex);
            BigInteger hsh = BigInteger.Parse(hex, System.Globalization.NumberStyles.HexNumber);

            BigInteger bigInteger_x = hsh % 10;
            Console.WriteLine(bigInteger_x);
            int x = (int)bigInteger_x;
            int y = (int)Math.Pow(2, x); // g0 = 5
            int T1 = (int)Math.Pow(2, r); // r: random number

            int inpu = y + T1 + a;
            byte[] byte_inpu = Encoding.UTF8.GetBytes(inpu.ToString());

            // Hash the input using SHA-1
            hash = sha1.ComputeHash(byte_inpu);
            hex = BitConverter.ToString(hash).Replace("-", "");
            hsh = BigInteger.Parse(hex, System.Globalization.NumberStyles.HexNumber);

            BigInteger bigInteger_c = hsh % 10;
            int c = (int)bigInteger_c;
            int z = r - (c * x);

            byte[] byte_z = Encoding.UTF8.GetBytes(z.ToString());
            byte[] byte_c = Encoding.UTF8.GetBytes(c.ToString());
            stream.Write(byte_c, 0, byte_c.Length);
            stream.Write(byte_z, 0, byte_z.Length);
            Console.WriteLine("Are u ok?");

            bytes = stream.Read(buffer, 0, buffer.Length); // 
            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytes));



            /*if (txt_UserName.Text.Equals("admin")&& txt_Pass.Text.Equals("123456"))
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show(@"Dang nhap thanh cong", @"System massage") ;
                //Mở form mới và đóng form cũ 
                Main frm = new Main();
                this.Hide();
                frm.Show();
                return;
            }
            else MessageBox.Show(@"Đã nhập sai user hoặc password", @"System message");*/
        }


        private void Form_Login_Load_1(object sender, EventArgs e)
        {

        }

        private void txt_Register_Click(object sender, EventArgs e)
        {
            Form_Register frmrg = new Form_Register();
            frmrg.ShowDialog();
        }

        private void txt_Register_CursorChanged(object sender, EventArgs e)
        {
            txt_Register.Font = new Font(txt_Register.Font, FontStyle.Bold);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}