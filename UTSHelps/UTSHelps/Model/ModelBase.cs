using System;
using System.Net.Http;

namespace UTSHelps.Model
{
	public partial class ModelBase
	{
		public delegate void VoidDelegate();
		public VoidDelegate OnDataUpdated {get; set;}

		public ModelBase ()
		{
		}
	}
}

