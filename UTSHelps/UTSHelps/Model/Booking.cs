﻿using System;

namespace UTSHelps.Model
{
	public class Booking
	{
		public Session BookedSession { get; set; }
		public BookingStatuses BookingStatus { get; set; }

		public Booking ()
		{
		}
	}
}
