using System;
using UTSHelps.Model;

namespace UTSHelps.DependencyServices
{
	public interface IEvent
	{
		void AddEvent(string name, DateTime startTime, DateTime endTime);
	}
}

