using System;
using System.Collections;
using System.Collections.Generic;

namespace UTSHelps.Model
{
	public class Bookings : HelpsBase
	{
		protected List<Workshop> bookings = new List<Workshop>();

		public Bookings ()
		{
		}

		public bool IsWorkshopInBooking(string workshopId)
		{
			return GetBooking (workshopId) != null;
		}

		public Booking GetBooking(string workShopId)
		{
			

			return null;
		}

	}
}

