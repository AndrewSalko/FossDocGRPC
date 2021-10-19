using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Foss.FossDoc.GRPC5.Service;
using Grpc.Core;


namespace ClientConsoleApp462
{
	class Program
	{
		static async Task Main(string[] args)
		{
			try
			{
				Console.WriteLine(".NET 4.6.2 gRPC client app");

				//открыть порт, выполнить тест запрос-ответ

				Channel channel = new Channel("127.0.0.1:5000", ChannelCredentials.Insecure);

				var authClient = new Foss.FossDoc.GRPC.Authentication.Authenticator.AuthenticatorClient(channel);
				var authReq = new Foss.FossDoc.GRPC.Authentication.AuthRequest();
				authReq.Login = "Andrew";
				authReq.Password = "123";

				var reply = authClient.Login(authReq);
				Console.WriteLine($"Auth reply: {reply.Token}");

				await channel.ShutdownAsync();

				Console.WriteLine("Done");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		void _Test()
		{
			//var client = new Greeter.GreeterClient(channel);
			//string user = "Andrew Salko";

			////CallOptions opts = new CallOptions();
			//Metadata meta = new Metadata();
			//meta.Add("Auth", "MY_TOKEN");

			//var reply = client.SayHello(new HelloRequest { Name = user }, meta);
			//Console.WriteLine("Greeting: " + reply.Message);

			////а теперь подписка на события и получаем их:
			//var eventsClient = new EventsHub.EventsHubClient(channel);

			//int count = 0;

			//var responseEvents = eventsClient.Subscribe(new SubcribeRequest());
			//while (await responseEvents.ResponseStream.MoveNext())
			//{
			//	ServerEvent evt = responseEvents.ResponseStream.Current;
			//	Console.WriteLine(evt.Message);

			//	count++;

			//	if (count > 10)
			//	{
			//		responseEvents.Dispose();
			//		break;
			//	}
			//}
		}

	}
}
