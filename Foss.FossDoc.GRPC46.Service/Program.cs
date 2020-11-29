using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foss.FossDoc.GRPC46.Service.Services;
using Foss.FossDoc.GRPC5.Service;
using Grpc.Core;

namespace Foss.FossDoc.GRPC46.Service
{
	class Program
	{
		static void Main(string[] args)
		{
			int port = 5000;

			Server server = new Server
			{
				Services = { Greeter.BindService(new GreeterService()) },
				Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
			};
			server.Start();

			Console.WriteLine("Server listening on port " + port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

		}

		void _Test1()
		{
			Foss.FossDoc.GRPC5.Service.OID oid = new OID();
			//oid.BaseAndData1 == (int, int)
			//oid.Data23       == (uint)
			//oid.Data4047     == ulong

		}

	}
}
