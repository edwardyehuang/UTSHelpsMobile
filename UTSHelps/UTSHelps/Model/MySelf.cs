using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UTSHelps.Server;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace UTSHelps.Model
{
	public class MySelf : HelpsBase
	{
		public SelfInfo Info { get ; set; }= new SelfInfo();
		public delegate void RegStudentDelegate(bool IsSuccess);


		public override void UpdateData ()
		{
			base.UpdateData ();

			if (Info.StudentId.Equals ("")) {


			} 
		}

		public void RegStudent(string studentId, RegStudentDelegate callback)
		{
			Info.CreatorId = Info.StudentId = studentId;

			string jsonStr = JsonConvert.SerializeObject (Info);

			var request = new HttpRequestMessage (HttpMethod.Post, "api/student/register") {

				Content = new StringContent (jsonStr, Encoding.UTF8, "application/json"),
			};

			server.SendJsonRequest (request, (string resultsRead) => {

				try
				{
					Debug.WriteLine("Reg response : " + resultsRead);
					JObject results = JObject.Parse (resultsRead);

					Debug.WriteLine(results["IsSuccess"].ToString());

					if (results["IsSuccess"].ToString().Equals("True"))
					{
						App.Setting.SetSettingValue("UserInfo", jsonStr);
						callback(true);
					}
					else
					{
						callback(false);
					}
				}
				catch (Exception e)
				{

				}
			});
		}

		public void RecordAttendance(string requestPart, Action <bool>callback)
		{
			var request = new HttpRequestMessage (HttpMethod.Post, "api/workshop/attendance?StudentId=" + Info.StudentId + "&" + requestPart);

			server.SendRequest (request, (string resultsRead) => {

				try
				{
					JObject results = JObject.Parse (resultsRead);

					Debug.WriteLine(results["IsSuccess"].ToString());

					callback(results["IsSuccess"].ToString().Equals("True"));
				}
				catch (Exception e)
				{
					
				}
			});
		}


		public void ReadDataFromLocal()
		{
			

		}

		public MySelf ()
		{
			
		}
	}
}

