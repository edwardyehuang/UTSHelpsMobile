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


		public override void UpdateData ()
		{
			base.UpdateData ();

			if (Info.StudentId.Equals ("")) {


			} 

			string jsonStr = JsonConvert.SerializeObject (Info);
		}

		public void RegStudent(string studentId)
		{
			Info.StudentId = studentId;


			string jsonStr = JsonConvert.SerializeObject (Info);

			server.SendRequest (new HttpRequestMessage (HttpMethod.Post, "api/student/register"){

			//	Content = new StringContent(content.ToString()),
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

