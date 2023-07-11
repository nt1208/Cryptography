using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Numerics;

namespace Server
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
        }

        private void serverBtn_Click(object sender, EventArgs e)
        {
            serverBtn.Enabled = false;   
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket successfully created");

            // reserve a port on your computer in our
            // case it is 12345 but it can be anything
            int port = 9999;

            // Next bind to the port
            // we have not typed any ip in the ip field
            // instead we have inputted an empty string
            // this makes the server listen to requests
            // coming from other computers on the network
            s.Bind(new IPEndPoint(IPAddress.Any, port));
            //Console.WriteLine("Socket binded to {0}", port);

            // put the socket into listening mode
            s.Listen(5);
            //Console.WriteLine("Socket is listening");

            // a forever loop until we interrupt it or
            // an error occurs
            int req;
            while (true)
            {
                // Establish connection with client.
                Socket c = s.Accept();
                Console.WriteLine("Got connection from {0}", c.RemoteEndPoint);

                byte[] nofi1 = Encoding.UTF8.GetBytes("\n1->Login\n2->NewUser");
                byte[] nofi2 = Encoding.UTF8.GetBytes("Login Procedure initiating");
                byte[] nofi3 = Encoding.UTF8.GetBytes("Access Granted ,You have been successfully logged in");
                byte[] nofi4 = Encoding.UTF8.GetBytes("The user_name or Password you entered is wrong");
                byte[] nofi5 = Encoding.UTF8.GetBytes("\nThank you for connecting");

                //c.Send(nofi1);
                byte[] buffer = new byte[1024];
                int bytesRead = c.Receive(buffer); // nhan option tu client
                req = int.Parse(Encoding.UTF8.GetString(buffer, 0, bytesRead));

                if (req == 1) // sign in
                {
                    //c.Send(nofi2);
                    Random rand = new Random();
                    int a = rand.Next(1, 11);
                    byte[] byte_a = Encoding.UTF8.GetBytes(a.ToString());
                    c.Send(byte_a); // random number a is generated

                    bytesRead = c.Receive(buffer); 
                    string uid = Encoding.UTF8.GetString(buffer, 0, bytesRead); // receive username

                    bytesRead = c.Receive(buffer);
                    int c1 = int.Parse(Encoding.UTF8.GetString(buffer, 0, bytesRead)); // receive c

                    bytesRead = c.Receive(buffer);
                    int z = int.Parse(Encoding.UTF8.GetString(buffer, 0, bytesRead)); // receive z

                    using (var reader = new StreamReader("Signin.csv"))
                    using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            string currUid = csv.GetField<string>("user_id");
                            if (currUid == uid)
                            {
                                int y = csv.GetField<int>("Password");
                                int T1 = (int)Math.Pow(y, c1) * (int)Math.Pow(2, z);
                                string inpu = (y + T1 + a).ToString();
                                SHA1 sha = new SHA1CryptoServiceProvider();
                                byte[] inputBytes = Encoding.UTF8.GetBytes(inpu);
                                byte[] hashBytes = sha.ComputeHash(inputBytes);
                                string hex = BitConverter.ToString(hashBytes).Replace("-", "");
                                BigInteger hsh = BigInteger.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                                BigInteger biginteger_c2 = hsh % 10;
                                int c2 = (int) biginteger_c2;

                                if (c2 == c1)
                                {
                                    c.Send(nofi3);
                                }
                                else
                                {
                                    c.Send(nofi4);
                                }

                                break;
                            }
                        }
                    }
                }
                else if (req == 2)
                {
                    c.Send(Encoding.UTF8.GetBytes("Sign up"));

                    byte[] bufferUid = new byte[1024];
                    int bytesReadUid = c.Receive(bufferUid); // nhan username
                    string uid = Encoding.UTF8.GetString(bufferUid, 0, bytesReadUid);

                    byte[] bufferPw = new byte[1024];
                    int bytesReadPw = c.Receive(bufferPw); // nhan y = g^x
                    string pw = Encoding.UTF8.GetString(bufferPw, 0, bytesReadPw);

                    //Luu vao database
                    using (var writer = new StreamWriter("Signin.csv", true))
                    using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
                    {
                        csv.WriteField(uid);
                        csv.WriteField(pw);
                        csv.NextRecord();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                // send a thank you message to the client.
                c.Send(nofi5);

                // Close the connection with the client
                c.Shutdown(SocketShutdown.Both);
                c.Close();
            }
        }


        private void server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }

}

