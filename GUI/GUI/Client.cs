using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GUI
{
    public class Client
    {
        private byte[] bytes;
        private Socket s;
        public Client(int port)
        {
            bytes = new byte[1024];

            // Get IPs of the server host.
            IPAddress[] IPs = Dns.GetHostAddresses("127.0.0.1");

            // Initialize a TCP socket of IPv4 type.
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Initialized client.");

            // Connect to the server in the first IP and given port.
            s.Connect(IPs[0], port);
            Console.WriteLine("Connection established.");
        }

        /// <summary>
        /// Converts string to bytes and sends it to the server.
        /// </summary>
        /// <param name="msg"></param>
        public void Send(string msg)
        {
            s.Send(Encoding.UTF8.GetBytes(msg));
            var tmp = Encoding.UTF8.GetBytes(msg);
            Console.WriteLine("Sent message.");
           
            
        }

        /// <summary>
        /// Saves received bytes from server in bytesArray parameter of the class and converts it to string.
        /// </summary>
        /// <returns></returns>
        public string Receive()
        {
            // Saves the bytes count of the message in length variable.
            int length = s.Receive(bytes);
            Console.WriteLine("Got message.");

            // Decodes the byte array back into a string and returns it.
            // Encoding.ASCII.GetString({bytes array}, {index of first byte to decode}, {count of bytes to decode})
            string data = Encoding.UTF8.GetString(bytes, 0, length);
            return data;
        }

        public void Close()
        {
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }
    }
}
