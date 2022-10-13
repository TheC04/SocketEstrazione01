using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {

        public static string data = null;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Server: Acceso";
            button1.Text = "Spegni";
            Application.DoEvents();
            StartListening();
        }
        public static void StartListening()
        {
            byte[] bytes = new Byte[1024];

            IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (true)
                {
                    Socket handler = listener.Accept();
                    data = null;
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }
                    MessageBox.Show(data.ToString().Split('<')[0]);
                    string a = "nope";
                    string s = data.Split(' ')[1];
                    foreach (string line in System.IO.File.ReadLines(@"../../../users/users.txt"))
                    {
                        if (s.ToLower() == line)
                        {
                            Random r = new Random();
                            a = r.Next(0, 11).ToString();
                            break;
                        }
                    }
                    if (a == "nope")
                    {
                        a = "You are not in the list. If you want to be added contact the developer";
                        MessageBox.Show("He is not in the list");
                    }
                    else
                    {
                        MessageBox.Show("I give him number " + a);
                    }
                    byte[] msg = Encoding.ASCII.GetBytes(a);
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            MessageBox.Show("Connection closed");
        }
    }
}
