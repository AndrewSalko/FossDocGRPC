using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foss.FossDoc.GRPC5.Service;
using Grpc.Core;


namespace ClientConsoleApp462
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine(".NET 4.6.2 gRPC client app");

				//открыть порт, выполнить тест запрос-ответ

				Channel channel = new Channel("127.0.0.1:5000", ChannelCredentials.Insecure);

				var client = new Greeter.GreeterClient(channel);
				string user = "Andrew Salko";

				var reply = client.SayHello(new HelloRequest { Name = user });
				Console.WriteLine("Greeting: " + reply.Message);

				channel.ShutdownAsync().Wait();

				Console.WriteLine("Done");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
