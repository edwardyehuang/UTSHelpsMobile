using System;

namespace UTSHelps.Model
{
	public class Booking : HelpsBase
	{
		public Session BookedSession { get; set; }
		public BookingStatuses BookingStatus { get; set; }

		public Booking ()
		{
		}
	}
}

