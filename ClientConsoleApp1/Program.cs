using System;
using Grpc.Net.Client;


using System.Threading.Tasks;

namespace ClientConsoleApp1
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("gRPC client app");

			//FDGRPCService.HelloRequest helloRequest = new FDGRPCService.HelloRequest
			//{
			//	Name = "Andrew Salko"
			//};

			//string url = "http://localhost:5000";

			//using var channel = GrpcChannel.ForAddress(url);
			//var client = new Greeter.GreeterClient(channel);
			//var reply = await client.SayHelloAsync(helloRequest);

			//Console.WriteLine("Greeting: " + reply.Message);

			Console.WriteLine("Press Enter...");
			Console.ReadLine();
		}
	}
}
