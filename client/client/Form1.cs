using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {
            string Sender = name.Text;
            byte[] bytes = new byte[1024];

            try
            {
                IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);

                Socket send = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    send.Connect(remoteEP);

                    messages.Text = "C:\tSocket connected to " + send.RemoteEndPoint.ToString() + "\n";

                    messages.Text = messages.Text + "C:\tI'm " + Sender + " can you give me a number?\n";
                    byte[] msg = Encoding.ASCII.GetBytes("I'm " + Sender + " can you give me a number?<EOF>");

                    int bytesSent = send.Send(msg);

                    int bytesRec = send.Receive(bytes);
                    if (Encoding.ASCII.GetString(bytes, 0, bytesRec) == "nope")
                    {
                        messages.Text = messages.Text + ("S:\tYou are not in the list. If you want to be added contact the developer");
                    }
                    else
                    {
                        messages.Text = messages.Text + ("S:\tThe random number is " + Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    }

                    send.Shutdown(SocketShutdown.Both);
                    send.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception en)
                {
                    Console.WriteLine("Unexpected exception : {0}", en.ToString());
                }

            }
            catch (Exception en)
            {
                Console.WriteLine(en.ToString());
            }
        }
    }
}
