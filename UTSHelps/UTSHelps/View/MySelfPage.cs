using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace UTSHelps.View
{
	public class MySelfPage : ContentPage
	{
		public TableView SelfTable { protected set; get;}
		public TableSection BasicInfoSection { protected set; get;}

		public Entry nameEntry = new Entry {
			Placeholder = "Name",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		public Entry phoneEntry = new Entry {
			Placeholder = "Preffered Phone",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};
			
		public Picker degreePicker = new Picker
		{
			Title = "Degree",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		public Dictionary<string, string> nameToDegree = new Dictionary<string, string>
		{
			{ "Undergraduate", "UG" }, 
			{ "Postgraduate", "PG" },
		};

		// permanent / international
		public Picker statusPicker = new Picker
		{
			Title = "Status",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		public Dictionary<string, string> nameToStatus = new Dictionary<string, string>
		{
			{ "Permanent resident", "Permanent" }, 
			{ "International student", "International" },
		};

		// year
		public Picker yearPicker = new Picker
		{
			Title = "Year",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		public Dictionary<string, string> nameToYear = new Dictionary<string, string>
		{
			{ "1st year", "1st" }, 
			{ "2nd year", "2nd" },
			{ "3rd year", "3rd" },
			{ "4th year", "4th" },
			{ "5th year", "5th" }
		};

		// DOB
		public DatePicker dobPicker = new DatePicker
		{
			Format = "MMMM d, yyyy",
			MaximumDate = new DateTime(2000, 1, 1),
			MinimumDate = new DateTime(1900, 1, 1),
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		// Gender
		public Picker genderPicker = new Picker
		{
			Title = "Gender",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		public Dictionary<string, string> nameToGender = new Dictionary<string, string>
		{
			{ "Male", "M" }, 
			{ "Female", "F" },
			{ "Unspecified", "X" }
		};

		// country
		public Picker countryPicker = new Picker
		{
			Title = "Country",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		// language
		public Picker langPicker = new Picker
		{
			Title = "Language",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		public MySelfPage ()
		{
			Title = "Profile";
			Icon = "icon_self";
			NavigationPage.SetBackButtonTitle (this, "Back");

			// fill all pickers
			foreach (string item in nameToDegree.Keys)
				degreePicker.Items.Add(item);
			
			foreach (string year in nameToYear.Keys)
				yearPicker.Items.Add(year);
			
			foreach (string item in nameToStatus.Keys)
				statusPicker.Items.Add(item);

			foreach (string item in nameToGender.Keys)
				genderPicker.Items.Add(item);

			foreach (string item in countries)
				countryPicker.Items.Add(item);

			foreach (string item in languages)
				langPicker.Items.Add(item);

			Content = new StackLayout
			{
				Spacing = 10, // vertical spacing
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (10, 10, 10, 10),
				Children = 
				{
					// name & phone
					new StackLayout
					{
						Spacing = 5,
						Orientation = StackOrientation.Horizontal,
						Children = 
						{
							nameEntry, phoneEntry
						}
					},

					// degree & year
					new StackLayout
					{
						Spacing = 5,
						Orientation = StackOrientation.Horizontal,
						Children = 
						{
							degreePicker, yearPicker
						}
					},

					// permanent / international
					statusPicker,

					// country & language
					new StackLayout
					{
						Spacing = 5,
						Orientation = StackOrientation.Horizontal,
						Children = 
						{
							countryPicker, langPicker
						}
					},

					// gender & birthday
					new StackLayout
					{
						Spacing = 5,
						Orientation = StackOrientation.Horizontal,
						Children = 
						{
							genderPicker, dobPicker
						}
					},

					new Button
					{
						Text = "Update",
						HorizontalOptions = LayoutOptions.FillAndExpand
					},

					new Button
					{
						Text = "Logout",
						HorizontalOptions = LayoutOptions.Center
					}
				}
			};
		}
			
		public string[] countries = { "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua", "Argentina", "Armenia", "Aruba", "Ascension Island", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bangladesh", "Barbados", "Barbuda", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegowina", "Botswana", "Brazil", "British Virgin Islands", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde Islands", "Cayman Islands", "Central African Republic", "Chad", "Chatham Island", "Chile", "China", "Christmas Island", "Cocos-Keeling Islands", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Cuba", "Croatia", "Curacao", "Cyprus", "Czech Republic", "Denmark", "Diego Garcia", "Dominica", "Dominican Republic", "D'Jibouti", "Easter Island", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Faroe Islands", "Falkland Islands", "Fiji Islands", "Finland", "France", "French Antilles", "French Giuana", "French Polynesia", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Grenadine Islands", "Guadalupe", "Guam", "Guantanamo Bay (Cuba)", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea (Republic of)", "Kuwait", "Kyrgyz Republic", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritus", "Mayotte Island", "Mexico", "Micronesia", "Midway Island","Moldova (Republic of)", "Monaco", "Mongolia", "Montserat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "Nevis", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Marianas Islands", "Norway", "Oman", "Pakistan", "Palau", "Palestine", "Panama", "Papua New Guinea", "Paraguay","Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Réunion Island", "Romania", "Russian Federation", "Rwanda", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "Spain", "Sri Lanka", "St. Helena", "St. Kitts", "St. Lucia", "St. Pierre et Miquelon", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Tahiti", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tokelau Islands", "Tonga Islands", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "US Virgin Islands", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Wake Island", "Wallis and Futuna Islands", "Western Samoa","Yemen-Arab Republic", "Zambia", "Zanzibar", "Zimbawe" };
		public string[] languages = { "Abkhazian", "Afar", "Afrikaans", "Albanian", "Amharic", "Arabic", "Armenian", "Assamese", "Aymara", "Azerbaijani", "Bashkir", "Basque", "Belarusian", "Bengali", "Bhutani", "Bihari", "Bislama", "Bosnian", "Breton", "Bulgarian", "Burmese", "Catalan", "Chinese (Cantonese)", "Chinese (Mandarin)", "Chinese (other)", "Corsican", "Croatian", "Czech", "Danish", "Dhivehi", "Dutch", "English", "Esperanto", "Estonian", "Faroese", "Farsi", "Fiji", "Finnish", "French", "Frisian", "Galician", "Ganda", "Georgian", "German", "Gree", "Greenlandic", "Guarani", "Gujarati", "Haitian Creole", "Hausa", "Hebrew", "Hindi", "Hungarian", "Icelandic", "Indonesian", "Inuktitut", "Inupiak", "Irish", "Italian", "Japanese", "Javanese", "Kannada", "Kashmiri", "Kazakh", "Khmer", "Kinyarwanda", "Kirundi", "Korean", "Kurdish", "Kyrgyz", "Laothian", "Latin", "Latvian", "Lingala", "Lithuanian", "Macedonian", "Malagasy", "Malay", "Malayalam", "Maltese", "Maori", "Marathi", "Moldavian", "Mongolian", "Nauru", "Nepali", "Norwegian (Bokmal)", "Norwegian (Nynorsk)", "Oriya", "Oromo", "Pashto/Pushto", "Polish", "Portuguese (Brazil)", "Portuguese", "Punjabi", "Quechua", "Rhaeto-Romance", "Romanian", "Russian","Samoan", "Sangho", "Sanskrit", "Scots Gaelic", "Serbian", "Serbo-Croatian", "Sesotho", "Setswana", "Shona", "Sindhi", "Sinhalese", "Siswati", "Slovak", "Slovenian", "Somali", "Spanish", "Sundanese", "Swahili", "Swedish", "Tagalog", "Tajik", "Tamil", "Tatar", "Telugu", "Thai", "Tibetan", "Tigrinya", "Tonga", "Tsonga", "Turkish", "Turkmen", "Twi", "Uighur", "Ukrainian", "Urdu", "Uzbek", "Vietnamese", "Volapuk", "Welsh", "Wolof", "Xhosa", "Yiddish", "Yiddish", "Zhuang", "Zulu" };
	}
}

