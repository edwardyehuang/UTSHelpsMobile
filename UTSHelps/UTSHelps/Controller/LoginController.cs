using System;
using Xamarin.Forms;
using UTSHelps.Model;
using UTSHelps.View;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UTSHelps.Controller
{
	public class LoginController : BaseController
	{
		public delegate void DataDelegate(string userName);
		public DataDelegate SuccessSignInEvent { get; set; }

		public LoginController () : base(new LoginPage())
		{
			
		}

		public void ReSignin()
		{
			((LoginPage)View).SignInButton.IsEnabled = true;
			((LoginPage)View).TitleLabel.Text = "UTS:Helps";
		}

		public void OnClickedOfflineButton()
		{
			View.Navigation.PopModalAsync (true);
		}

		public async void OnClickedLoginButton()
		{
			((LoginPage)View).SignInButton.IsEnabled = false;
			((LoginPage)View).TitleLabel.Text = "Waiting";

			using (HttpClient client = new HttpClient ()) {

				client.BaseAddress = new Uri ("http://grp15sdp.danward.me:8080/");

				HttpRequestMessage request = 
					new HttpRequestMessage (HttpMethod.Get, 
						"api/student/login?studentId=" + ((LoginPage)View).UsernameEntry.Text + 
						"&Password=" + ((LoginPage)View).PasswordEntry.Text);

				try
				{
					HttpResponseMessage httpRespose = await client.SendAsync (request);
					string resultStr = await httpRespose.Content.ReadAsStringAsync ();
					DidReadResponse(resultStr);

					Debug.WriteLine("Login Respones received");


				}
				catch(WebException e) {
					Debug.WriteLine ("Send request failed :" + e.Message);
				}
			}
		}

		public override void RegViewEvents ()
		{
			base.RegViewEvents ();
			//((LoginPage)View).OfflineButton.Clicked += (object sender, EventArgs e) => OnClickedOfflineButton ();
			((LoginPage)View).SignInButton.Clicked += (object sender, EventArgs e) => OnClickedLoginButton();
		}

		public void DidReadResponse (string stringRead)
		{
			try
			{
				((LoginPage)View).SignInButton.IsEnabled = true;

				Debug.WriteLine(stringRead);

				JObject results = JObject.Parse (stringRead);

				if (results["IsSuccess"].ToString().Equals("True"))
				{
					OnSuccessSignin();
				}
				else
				{
					OnFailSignin();
				}


			}
			catch (InvalidCastException e) {

				Debug.WriteLine ("Invaild data\n " + stringRead + "\n Error Message :" + e.Message);
			}
			catch (JsonException e) {

				Debug.WriteLine ("Invaild data\n " + stringRead + "\n Error Message :" + e.Message);
			}
		}

		public void OnSuccessSignin()
		{
			Debug.WriteLine ("Login Success !");

			if (SuccessSignInEvent != null) {

				SuccessSignInEvent(((LoginPage)View).UsernameEntry.Text);
			}

			View.Navigation.PopModalAsync (true);
		}

		public void OnFailSignin()
		{
			((LoginPage)View).TitleLabel.Text = "Failed";
			Debug.WriteLine ("Login Fail !");
		}

	}
}

