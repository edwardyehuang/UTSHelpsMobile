using System;
using UTSHelps.View;
using UTSHelps.Model;

namespace UTSHelps.Controller
{
	public class WorkShopsController : BaseController
	{
		public WorkShopsController () : base(new WorkShopsPage(), new WorkShops())
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			WorkShops shops = (WorkShops)Model;

			shops.UpdateData ();
		}

		public override void UpdateView ()
		{
			base.UpdateView ();

			WorkShops shops = (WorkShops)Model;
			WorkShopsPage page = (WorkShopsPage)View;

			foreach (Workshop shop in shops.Shops) {

				
			}
		}
	}
}

