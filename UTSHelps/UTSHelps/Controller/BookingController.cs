using System;
using UTSHelps.View;
using UTSHelps.Model;

namespace UTSHelps.Controller
{
	public class BookingController : BaseController
	{
		public BookingController (MainData mainData) : base(new BookingPage(), mainData.BookingsData)
		{
		}
	}
}

