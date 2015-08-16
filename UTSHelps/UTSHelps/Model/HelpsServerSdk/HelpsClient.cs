using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UTSHelps.Server
{
	public interface HelpsClient
	{
		void DidReceiveResponse (HelpsServerResponse response);
	}
}

