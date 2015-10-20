using System;
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
	public class WorkshopSet : HelpsBase
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Archived { get; set; }
		public Workshops SetWorkshops { get; set; }
		public BookingStatuses BookingStatus { get; set; }

		public WorkshopSet () : base()
		{
			
		}



		public override void DidReadResponse (string stringRead)
		{
			base.DidReadResponse (stringRead);


		}
			
	}
}

