using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foss.FossDoc.GRPC46.Service.Services;
//using Foss.FossDoc.GRPC;
using Grpc.Core;

namespace Foss.FossDoc.GRPC46.Service
{
	class Program
	{
		static void Main(string[] args)
		{
			int port = 5000;

			//Для приложения .NET Framework 4.6.2 есть проблема - при использовании проекта .NET Stand 2.0 не видит "обертки" protobuf
			//поэтому пришлось явно прицепить auth.proto

			Server server = new Server
			{
				Services =
				{
					Foss.FossDoc.GRPC.Authentication.Authenticator.BindService(new Services.AuthenticationService() )
					
					//Greeter.BindService(new GreeterService()),
					//EventsHub.BindService(new EventsHubService())
				},
				Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) },
			};

			server.Start();

			Console.WriteLine("Server listening on port " + port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

		}

		void _Test1()
		{
			//Foss.FossDoc.GRPC46.Service.Services.

			//Foss.FossDoc.GRPC.OID oid = new OID();
			//oid.BaseAndData1 == (int, int)
			//oid.Data23       == (uint)
			//oid.Data4047     == ulong

		}

	}
}
