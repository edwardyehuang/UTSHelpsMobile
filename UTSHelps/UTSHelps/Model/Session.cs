using System;

namespace UTSHelps.Model
{
	public class Session : HelpsBase
	{
		public string Name { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int Number {get; set;}
		public int PlacesAvailable { get; set; }

		public string TargetGroup { get; set; }
		public string Information { get; set; }

		public string Location { get; set; }

		public Session ()
		{
			
		}
	}
}

