using System;

namespace UTSHelps.Model
{
	public class MainData
	{
		public WorkShops WorkShopsData { get; set; }
		public Bookings BookingsData { get; set; }
		public MySelf SelfData { get; set; }

		public MainData ()
		{
			WorkShopsData = new WorkShops{ HelpsData = this };
			BookingsData = new Bookings{ HelpsData = this };
			SelfData = new MySelf{ HelpsData = this };
		}
	}
}

