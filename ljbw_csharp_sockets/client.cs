using System.Text;
using System.Net;
using System.Net.Sockets;

public class GetSocket
{
    public static void Main()
    {
        IPEndPoint ipe = new IPEndPoint(IPAddress.Loopback, 7000);

        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sock.Connect(ipe);

        Byte[] bytesToSend;

        Console.WriteLine("Enter text to send through the socket. Enter \"quit\" to stop the program.");

        while (true)
        {
            string? readLine = Console.ReadLine();

            if (readLine != null)
            {
                bytesToSend = Encoding.ASCII.GetBytes(readLine);

                sock.Send(bytesToSend);

                if (readLine == "quit")
                {
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                    break;
                }
            }
        }
    }
}