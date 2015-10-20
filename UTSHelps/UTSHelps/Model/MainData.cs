using System;

namespace UTSHelps.Model
{
	public class MainData
	{
		public WorkShopSets WorkShopsData { get; set; }
		public Bookings BookingsData { get; set; }
		public MySelf SelfData { get; set; }

		public MainData ()
		{
			WorkShopsData = new WorkShopSets{ HelpsData = this };
			BookingsData = new Bookings{ HelpsData = this };
			SelfData = new MySelf{ HelpsData = this };
		}
	}
}

