using System;
using Grpc.Net.Client;


using System.Threading.Tasks;

using Grpc.Core;


namespace ClientConsoleApp5
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("gRPC client app");

			var channel = new Channel("127.0.0.1:5000", ChannelCredentials.Insecure);

			//Тест клиента аутентификации: приложение на .NET 5 способно "увидеть" сборку Foss.FossDoc.Protos (.NET Stand 2.0)
			//и использовать собранные обертки gRPC из нее

			var authClient = new Foss.FossDoc.GRPC.Authentication.Authenticator.AuthenticatorClient(channel);
			var authReq = new Foss.FossDoc.GRPC.Authentication.AuthRequest();
			authReq.Login = "Andrew";
			authReq.Password = "123";

			var reply = authClient.Login(authReq);
			Console.WriteLine($"Auth reply: {reply.Token}");

			
			//	var client = new Greeter.GreeterClient(channel);
			//	string user = "Andrew Salko from .NET 5";
			//	var reply = client.SayHello(new HelloRequest { Name = user });
			//	Console.WriteLine("Greeting: " + reply.Message);
			

			await channel.ShutdownAsync();

			Console.WriteLine("Press Enter...");
			Console.ReadLine();
		}
	}
}
