using System;

namespace UTSHelps.Model
{
	public class Booking : HelpsBase
	{
		public Workshop BookedWorkshop { get; set; }
		public BookingStatuses BookingStatus { get; set; }

		public Booking ()
		{
		}

	
	}
}

