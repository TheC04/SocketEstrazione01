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
using System.Threading;

namespace server
{
    public partial class Form1 : Form
    {

        public static string data = null;
        bool on = false;
        Thread t;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls=false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!on)
            {
                label1.Text = "Server: Acceso";
                button1.Text = "Spegni";
                on = true;
                messages.Text = "Server acceso\n";
                Application.DoEvents();
                t = new Thread(StartListening);
                t.Start();
            }
            else
            {
                on = false;
                messages.Text = messages.Text + "Server spento\n";
                label1.Text = "Server: Spento";
                button1.Text = "Accendi";
            }
        }
        public void StartListening()
        {
            byte[] bytes = new Byte[1024];

            IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                if (on)
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);
                }

                while (on)
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
                    ch_text("C:\t" + (data.ToString().Split('<')[0]) + "\n");
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
                        ch_text("S:\tYou are not in the list\n");
                    }
                    else
                    {
                        ch_text("S:\tI give you number " + a + "\n");
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
            ch_text("Connection closed\n");
        }

        private void ch_text(string s)
        {
            messages.Text+=s;
        }
    }
}
