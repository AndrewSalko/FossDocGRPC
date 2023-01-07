using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foss.FossDoc.GRPC.Authentication;
using Grpc.Core;


namespace Foss.FossDoc.GRPC5.Service.Services
{
	class AuthenticationService: Foss.FossDoc.GRPC.Authentication.Authenticator.AuthenticatorBase
	{

		public override Task<AuthReply> Login(AuthRequest request, ServerCallContext context)
		{
			const string authKey = "Authorization";

			var meta = context.RequestHeaders;
			if (meta != null)
			{
				var entry = meta.Get(authKey);
				if (entry != null)
				{
					Console.WriteLine($"Login:  {authKey}:{entry.Value}");
				}
			}


			AuthReply authReply = new AuthReply();
			authReply.Token = "result token";

			return Task.FromResult(authReply);
		}

	}
}
