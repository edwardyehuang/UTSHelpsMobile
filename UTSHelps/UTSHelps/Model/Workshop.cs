using System;

namespace UTSHelps.Model
{
	public class Workshop
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Archived { get; set; }
		public Sessions WorkShopSessions { get; set; }

		public Workshop ()
		{
			
		}
	}
}

