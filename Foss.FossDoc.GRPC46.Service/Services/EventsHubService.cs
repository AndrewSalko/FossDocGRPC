using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Foss.FossDoc.GRPC.Events;
using Grpc.Core;


namespace Foss.FossDoc.GRPC46.Service.Services
{
	///// <summary>
	///// Пример событий от сервера на клиент.
	///// См. статью https://docs.microsoft.com/ru-ru/dotnet/architecture/grpc-for-wcf-developers/rpc-types
	///// </summary>
	//public class EventsHubService: FossDoc.GRPC.EventsHub.EventsHubBase
	//{
	//	public EventsHubService()
	//	{
	//	}

	//	public override async Task Subscribe(SubcribeRequest request, IServerStreamWriter<ServerEvent> responseStream, ServerCallContext context)
	//	{
	//		while (!context.CancellationToken.IsCancellationRequested)
	//		{
	//			var time = DateTimeOffset.UtcNow;

	//			await responseStream.WriteAsync(new ServerEvent { Message = $"The time is {time:t}." });

	//			await Task.Delay(TimeSpan.FromSeconds(10), context.CancellationToken);
	//		}
	//	}

	//}
}
