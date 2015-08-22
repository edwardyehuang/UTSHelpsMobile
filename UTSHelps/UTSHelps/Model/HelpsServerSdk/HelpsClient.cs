using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UTSHelps.Server
{
	public interface HelpsClient
	{
		Task DidReceiveResponse (HttpResponseMessage response);
	}
}

