using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SignalRTry
{
	public class MyEndpoint : PersistentConnection 
	{
		protected override System.Threading.Tasks.Task OnConnected(IRequest request, string connectionId)
		{
			Debug.WriteLine("Endpoint:" + MethodBase.GetCurrentMethod().Name);
			return base.OnConnected(request, connectionId);
		}

		protected override System.Threading.Tasks.Task OnDisconnected(IRequest request, string connectionId)
		{
			Debug.WriteLine("Endpoint:" + MethodBase.GetCurrentMethod().Name);
			return base.OnDisconnected(request, connectionId);
		}
	}
}