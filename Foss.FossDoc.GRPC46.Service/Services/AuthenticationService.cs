using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foss.FossDoc.GRPC5.Service;
using Foss.FossDoc.GRPC5.Service.Authentication;
using Grpc.Core;


namespace Foss.FossDoc.GRPC46.Service.Services
{
	class AuthenticationService: Foss.FossDoc.GRPC5.Service.Authentication.Authenticator.AuthenticatorBase
	{

		public override Task<AuthReply> Login(AuthRequest request, ServerCallContext context)
		{
			AuthReply authReply = new AuthReply();
			authReply.Token = "result token";

			return Task.FromResult(authReply);
		}

	}
}
