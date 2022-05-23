using System;
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
            s.Send(Encoding.ASCII.GetBytes(msg));
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
            string data = Encoding.ASCII.GetString(bytes, 0, length);
            return data;
        }

        /// <summary>
        /// Gets file from server and saves it in filesReceived folder.
        /// </summary>
        /// <param name="filename"></param>
        public void GetFile(string filename)
        {
            string path = "C:\\Users\\idd\\Desktop\\Michals\\cyber\\Signatural\\filesReceived\\" + filename;

            // Opens a new file in write mode.
            using (FileStream file = File.Create(path))
            {
                // Receives packets with 1024 bytes and adds them to the file each time,
                // until the whole file was received.
                int length = s.Receive(bytes);
                while (length > 0)
                {
                    file.Write(bytes, 0, length); // file.write({byte array}, {index of start}, {bytes count})
                    length = s.Receive(bytes);
                }
                Console.WriteLine("Received file.");
            }
        }

        /// <summary>
        /// Sends file to server.
        /// </summary>
        /// <param name="filepath"></param>
        public void SendFile(string filepath)
        {
            // sends the filename
            string[] tmp = filepath.Split('\\');
            Console.WriteLine(tmp[tmp.Length - 1]); //
            s.Send(Encoding.ASCII.GetBytes(tmp[tmp.Length-1]));

            // Opens the specific file in read mode.
            using (FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                // Reads 1024 bytes, stores them in b and sends it each time,
                // untill there are no more bytes to read.
                byte[] b = new byte[1024];
                while (file.Read(b, 0, b.Length) > 0)
                {
                    s.Send(b);
                }
                Console.WriteLine("Sent file.");
            }
        }

        public void Close()
        {
            s.Close();
        }
    }
}
