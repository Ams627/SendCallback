using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SendCallback
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var address = "192.168.201.107";
                var port = 9999;
                var stringToSend = "APPELSGR";

                var client = new TcpClient(address, port);
                var stream = client.GetStream();
                var ba = Encoding.ASCII.GetBytes(stringToSend);
                stream.Write(ba, 0, ba.Length);
                stream.Close();
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
