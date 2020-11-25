using System;
using Grpc.Net.Client;


using System.Threading.Tasks;
using Foss.FossDoc.GRPC5.Service;
using Grpc.Core;

namespace ClientConsoleApp5
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("gRPC client app");

			var channel = new Channel("127.0.0.1:5000", ChannelCredentials.Insecure);

			var client = new Greeter.GreeterClient(channel);
			string user = "Andrew Salko from .NET 5";

			var reply = client.SayHello(new HelloRequest { Name = user });

			Console.WriteLine("Greeting: " + reply.Message);

			await channel.ShutdownAsync();

			Console.WriteLine("Press Enter...");
			Console.ReadLine();
		}
	}
}
