using System;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Concurrent;

namespace SignalRTry.Hubs
{
	public class QuestionHub : Hub
	{
		private static readonly ConcurrentDictionary<string, bool> _connections = new ConcurrentDictionary<string, bool>();

		/// <summary>
		/// クライアントから返事がきたとき
		/// </summary>
		/// <param name="message"></param>
		public void Answered(String message)
		{
			DateTime japanTime = DateTime.UtcNow.AddHours(9);
			Clients.All.NotifyAnswer(message, japanTime.ToString("yyyy/MM/dd HH:mm:ss"));
		}

		public override Task OnConnected()
		{
			_connections.TryAdd(Context.ConnectionId, true);
			return Clients.All.sendConnectionCount(_connections.Count);
		}

		public override Task OnDisconnected()
		{
			bool value;

			_connections.TryRemove(Context.ConnectionId, out value);
			return Clients.All.sendConnectionCount(_connections.Count);
		}

		public override Task OnReconnected()
		{
			_connections.TryAdd(Context.ConnectionId, true);
			return Clients.All.sendConnectionCount(_connections.Count);
		}
	}
}