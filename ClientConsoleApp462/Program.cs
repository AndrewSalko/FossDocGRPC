using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Grpc.Core;
using System.Collections;
using static System.Net.WebRequestMethods;
using System.Runtime.Remoting.Channels;


namespace ClientConsoleApp462
{
	class Program
	{
		static async Task Main(string[] args)
		{
			try
			{
				Console.WriteLine(".NET 4.6.2 gRPC client app");


				Channel channel = new Channel("127.0.0.1:5000", ChannelCredentials.Insecure);


				//var channel = Grpc.Net.Client.GrpcChannel.ForAddress("http://127.0.0.1:5000");
				//_WorkWithGRPC_NetClient(channel);

				//классич.работа - вызов с метаданными (токен аутентификации)
				_WorkWithGRPC(channel);

				await channel.ShutdownAsync();


				//var host = await _WorkWithDI(args);


				Console.WriteLine("Done");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		static void _WorkWithGRPC_NetClient(Grpc.Net.Client.GrpcChannel channel)
		{
			var authClient = new Foss.FossDoc.GRPC.Authentication.Authenticator.AuthenticatorClient(channel);

			var authReq = new Foss.FossDoc.GRPC.Authentication.AuthRequest();
			authReq.Login = "Andrew";
			authReq.Password = "123";

			string token = "test token";
			var metaData = new Metadata();
			metaData.Add("Authorization", $"Bearer {token}");

			var reply = authClient.Login(authReq, metaData);
			//var reply = authClient.Login(authReq);

			Console.WriteLine($"Auth reply: {reply.Token}");
		}



		static void _WorkWithGRPC(Channel channel)
		{
			var authClient = new Foss.FossDoc.GRPC.Authentication.Authenticator.AuthenticatorClient(channel);

			var authReq = new Foss.FossDoc.GRPC.Authentication.AuthRequest();
			authReq.Login = "Andrew";
			authReq.Password = "123";

			string token = "test token";
			var metaData = new Metadata();
			metaData.Add("Authorization", $"Bearer {token}");

			var reply = authClient.Login(authReq, metaData);
			//var reply = authClient.Login(authReq);

			Console.WriteLine($"Auth reply: {reply.Token}");
		}


		static async Task<IHost> _WorkWithDI(string[] args)
		{
			Console.WriteLine("DI mode");

			//https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
			//https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host
			//https://github.com/grpc/grpc-dotnet/tree/master/src/Grpc.Net.ClientFactory

			string authToken = "token_di";

			IHost host = Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
					{
						services.AddSingleton<IOperation, SingletonOperation>();

						//https://learn.microsoft.com/en-us/aspnet/core/grpc/authn-and-authz?view=aspnetcore-7.0
						services.AddGrpcClient<Foss.FossDoc.GRPC.Authentication.Authenticator.AuthenticatorClient>(cli =>
						{
							cli.Address = new Uri("http://127.0.0.1:5000");
							//cli.
						})
						.AddCallCredentials((context, metadata) =>
						{
							if (!string.IsNullOrEmpty(authToken))
							{
								metadata.Add("Authorization", $"Bearer {authToken}");
							}
							return Task.CompletedTask;
						});

					}
				).Build();

			//ExemplifyScoping(host.Services, "Scope 1");
			//ExemplifyScoping(host.Services, "Scope 2");

			//тест вызов: ожидаем что передача метаданных (токена) идет автоматически

			
			var authClient = host.Services.GetService<Foss.FossDoc.GRPC.Authentication.Authenticator.AuthenticatorClient>();

			var authReq = new Foss.FossDoc.GRPC.Authentication.AuthRequest();
			authReq.Login = "Andrew";
			authReq.Password = "123";

			var reply = authClient.Login(authReq);
			Console.WriteLine($"Auth reply: {reply.Token}");


			await host.RunAsync();

			return host;
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
