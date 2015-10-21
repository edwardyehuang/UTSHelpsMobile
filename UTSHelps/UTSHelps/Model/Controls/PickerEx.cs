using System;
using Xamarin.Forms;
using System.Collections.Generic;

// Enhanced Picker class 

namespace UTSHelps
{
	public class PickerEx: Picker
	{
		// key: displayed, value: used for API
		private Dictionary<string, string> dictionary;
			
		public Dictionary<string, string> Dictionary { 
			get {return dictionary;} 
			set 
			{ 
				dictionary = value;

				// fill picker with keys
				foreach (string item in value.Keys)
					this.Items.Add(item);
			}
		}

		public PickerEx () { }

		// search by text
		public void select(string value)
		{
			SelectedIndex = Items.IndexOf (value);
		}

		// search by short values
		public void search(string value)
		{
			var i = 0;
			foreach (string item in dictionary.Values) {

				if (item.Equals(value)) {
					SelectedIndex = i;
					break;
				}
				i++;
			}
		}

		// returns currently selected text 
		public string Value() 
		{
			if (SelectedIndex == -1) return null;

			// returns short values for API
			if (dictionary != null) 
				return dictionary [Items [SelectedIndex]];

			return Items [SelectedIndex];
		}
	}
}

