using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SynchronousSocketListener
{

    public static string data = null;

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
                Console.WriteLine("Waiting for a connection..."); 
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

                Console.WriteLine(data.ToString()+" is asking for a number.");

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
                }
                else
                {
                    Console.WriteLine("I give him number " + a);
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

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();

    }

    public static int Main(String[] args)
    {
        StartListening();
        return 0;
    }
}
