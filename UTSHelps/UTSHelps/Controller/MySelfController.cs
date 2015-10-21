using System;
using UTSHelps.View;
using UTSHelps.Model;
using System.Diagnostics;

namespace UTSHelps.Controller
{
	public class MySelfController : BaseController
	{
		protected MySelf mySelf = new MySelf();
		protected MySelfInfoController mySelfInfo;

		public MySelfController (MainData mainData) : base (new MySelfPage(), mainData.SelfData)
		{
		
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			// fill profile page
			var profile = ((MySelf)Model).Info;
			var page = (MySelfPage)View;

			page.nameEntry.Text = profile.PreferredName;
			page.phoneEntry.Text = profile.AltContact;

			page.countryPicker.select (profile.CountryOrigin);
			page.langPicker.select (profile.FirstLanguage);

			page.degreePicker.search (profile.Degree);
			page.yearPicker.search (profile.DegreeDetails);

			page.genderPicker.search (profile.Gender);
			page.statusPicker.search (profile.Status);

			page.dobPicker.Date = Convert.ToDateTime (profile.DateOfBirth);
		}

		public override void RegViewEvents ()
		{
			base.RegViewEvents ();

			((MySelfPage)View).registerButton.Clicked += (object sender, EventArgs e) => SendProfileInfo ();
		}

		public void SendProfileInfo()
		{
			var page = (MySelfPage)View;

			var profile = ((MySelf)Model).Info;

			// get data from UI
			profile.PreferredName = page.nameEntry.Text;
			profile.AltContact = page.phoneEntry.Text;

			profile.CountryOrigin = page.countryPicker.Value();
			profile.FirstLanguage = page.langPicker.Value();

			profile.Degree = page.degreePicker.Value();
			// current year
			profile.DegreeDetails = page.yearPicker.Value();

			profile.Status = page.statusPicker.Value();
			profile.Gender = page.genderPicker.Value();

			profile.DateOfBirth = page.dobPicker.Date.ToString ("d MMMM yyyy");

			// TODO: register student
//			mainData.SelfData.RegStudent (userName, IsSuccess => {
//				if (IsSuccess) ;
//				else {
					
//				}
//			});

		}

		public void ShowSelfInfoPage()
		{
			mySelfInfo = new MySelfInfoController();
		    View.Navigation.PushAsync (mySelfInfo.View);
		}
	}
}

