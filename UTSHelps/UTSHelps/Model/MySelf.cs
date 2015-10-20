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

			string jsonStr = JsonConvert.SerializeObject (Info);
		}

		public void RegStudent(string studentId, RegStudentDelegate callback)
		{
			Info.CreatorId = Info.StudentId = studentId;

			string jsonStr = JsonConvert.SerializeObject (Info);

			var request = new HttpRequestMessage (HttpMethod.Post, "api/student/register") {

				Content = new StringContent (jsonStr, Encoding.UTF8, "application/json"),
			};

			server.SendJsonRequest (request, (string resultsRead) => {


				Debug.WriteLine("Reg response : " + resultsRead);
				JObject results = JObject.Parse (resultsRead);

				Debug.WriteLine(results["IsSuccess"].ToString());

				if (results["IsSuccess"].ToString().Equals("True"))
				{
					callback(true);
				}
				else
				{
					callback(false);
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

