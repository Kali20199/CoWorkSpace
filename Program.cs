using System.Net;
using System.Net.Sockets;

namespace CoWorkSpace {
    public class Program
   
    {
        public static void Main(string[] args) {
        CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                       string localIP;
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    localIP = endPoint.Address.ToString();
                    Console.WriteLine("MyIp " + localIP);
                    webBuilder.UseUrls( "http://"+localIP+":5003");
                 
                     webBuilder.UseStartup<Startup>();
                });
    }
 



















}


