using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foss.FossDoc.GRPC5.Service.Services
{
	public class GreeterService : Greeter.GreeterBase
	{
		readonly ILogger<GreeterService> _Logger;

		public GreeterService(ILogger<GreeterService> logger)
		{
			_Logger = logger;
		}

		public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			return Task.FromResult(new HelloReply
			{
				Message = "Hello " + request.Name
			});
		}
	}
}
