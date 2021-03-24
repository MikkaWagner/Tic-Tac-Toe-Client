using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Tic_Tac_Toe_Client
{
    class Connection
    {
        private TcpClient tcp;
        private NetworkStream networkStream;
        bool connected;
        public Connection(string ip, int port)
        {
            this.tcp = new TcpClient(ip, port);
            this.networkStream = tcp.GetStream();
            connected = true;
            new Thread(readAll).Start();

        }

        public void SendMessage(string type, string value)
        {
            Console.WriteLine("--Client-send-type--> " + type);
            Console.WriteLine("--Client-send-value--> " + value);

            MessageCreator mC = new MessageCreator();
            mC.type = type;
            mC.value = value;
            string messageJson = JsonConvert.SerializeObject(mC);
            byte[] payload = Encoding.UTF8.GetBytes(messageJson);
            networkStream.Write(payload, 0, payload.Length);
            networkStream.Flush();
        }

        public string ReadMessage()
        {
            try
            {
                byte[] data = new byte[256];
                String responseData = String.Empty;
                Int32 byteCount = networkStream.Read(data, 0, data.Length);
                responseData = Encoding.UTF8.GetString(data, 0, byteCount);
                return responseData;
            }
            catch
            {
                return null;
            }
        }
        public void Disconnect()
        {
            MainWindow.wInput = false;
            connected = false;
            networkStream.Close();
            tcp.Close();
        }


        private void readAll()
        {

            while (connected)
            {

                MainWindow.window.process(ReadMessage());
            }

        }
    }

    class MessageCreator
    {
        public string type { get; set; }
        public string value { get; set; }
    }
}