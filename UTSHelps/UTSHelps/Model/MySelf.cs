using System;

namespace UTSHelps.Model
{
	public class MySelf : HelpsBase
	{
		public string Name {get; set;}
		public string PreferredFirstName { get; set; }
		public string Faculty { get; set; }
		public string Course { get; set; }
		public string Email { get; set; }
		public string HomePhone { get; set; }
		public string MobileNumber { get; set;}
		public string BestContactNumber { get; set; }
		public DateTime BirthDay { get; set; }
		public Genders Gender { get ; set; }
		public Degrees Degree { get; set; }
		public int CurrentYear { get; set; }




		public MySelf ()
		{
			
		}
	}
}

