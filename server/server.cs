using System.Text;
using System.Net;
using System.Net.Sockets;

// This program listens for a connection on 127.0.0.1:7000. It can be used to test the socket client.

Socket sock = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

sock.Bind(new IPEndPoint(IPAddress.Loopback, 7000));

sock.Listen();

int bytes;
Byte[] bytesReceived = new Byte[256];
string page;

Console.WriteLine("Waiting for a connection");
Socket clientSocket = sock.Accept();

while (true)
{
    bytes = clientSocket.Receive(bytesReceived);

    page = Encoding.ASCII.GetString(bytesReceived, 0, bytes);

    Console.WriteLine(page);

    // It would be better to detect that the sending socket has been closed, and stop automatically, than require the user to enter "quit".
    if (page == "quit")
    {
        Console.WriteLine("Quitting");
        sock.Close();
        clientSocket.Close();
        break;
    }
}
