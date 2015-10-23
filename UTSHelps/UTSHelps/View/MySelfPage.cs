using System;
using Xamarin.Forms;
using System.Collections.Generic;
using UTSHelps.Model;
using UTSHelps.UI;

namespace UTSHelps.View
{
	public class MySelfPage : ContentPage
	{
		public TableView SelfTable { protected set; get;} = new TableView();
		public TableSection BasicInfoSection { protected set; get;} = new TableSection();

		public MySelfPage ()
		{
			Title = "Profile";
			Icon = "icon_self";

			SelfTable.Intent = TableIntent.Settings;
			Content = SelfTable;


		}

		public void BuildTable (MainData data)
		{
			SelfInfo info = data.SelfData.Info;
			BasicInfoSection.Clear ();

			AddTextLabelCell ("ID", info.StudentId);



			AddTextLabelCell ("Contact number", info.AltContact, () =>
				PopEntryEditor ("Contant number", info.AltContact, changedText => info.AltContact = changedText));


		
			(SelfTable.Root = new TableRoot ()).Add (BasicInfoSection);
		}
		/*
		public void AddEntryCell (string label, Action action, string initialText)
		{
			EntryCell cell = CreateEntryCell (label, action, initialText);
			//cell.IsEnabled = false;
			BasicInfoSection.Add (cell);
		}

		public void AddReadOnlyEntryCell(string label, string text)
		{
			EntryCell cell = CreateEntryCell (label, null, text);
			cell.IsEnabled = false;

			BasicInfoSection.Add (cell);
		}
*/
		public void AddTextLabelCell (string label, string text, Action action = null)
		{
			var cell = new TextLabelCell (){ Label = label, Text = text };

			if (action != null) {
				cell.HasArrow = true;
				cell.Tapped += (sender, e) => action ();
			}

			BasicInfoSection.Add (cell);
		}

		protected EntryCell CreateEntryCell(string label, Action action, string initialText)
		{
			var entryCell = new EntryCell {
				Label = label,
				Text = initialText,
				XAlign = TextAlignment.End,
			};

			if (action != null) {
				entryCell.Tapped += (sender, e) => action();
			}

			return entryCell;
		}

		public void PopEntryEditor(string title, string initalText, Action<string> changedText, bool allowEmpty = false)
		{
			Entry entry = new Entry {
				Text = initalText,
				BackgroundColor = Color.White,
			};
				
			ContentPage popPage = new ContentPage {
				Title = title,
				Content = new StackLayout {
					Orientation = StackOrientation.Vertical,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.Start,
					Children = { entry },
				}
			};
					

			popPage.ToolbarItems.Add (new ToolbarItem ("Save", null, () => {
				if (allowEmpty || !entry.Text.Equals ("")) {
					changedText (entry.Text);
				}

				Navigation.PopAsync ();
			}));

			Navigation.PushAsync (popPage);
			entry.Focus ();
		}

		public void PopSelectionEditor(string title, string []selectionsText, Action<int> selection)
		{
			TableView selectionTable = new TableView();
			TableSection mainSection = new TableSection ();

			for (int i = 0; i < selectionsText.Length; i++) {
				TextCell cell = new TextCell { Text = selectionsText [i] };

				if (selection != null) {
					cell.Tapped += (object sender, EventArgs e) => {
						selection (i);
						Navigation.PopAsync();
					};
				}

				mainSection.Add (mainSection);
			}

			(selectionTable.Root = new TableRoot ()).Add (mainSection);
		}


		public string[] countries = { "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua", "Argentina", "Armenia", "Aruba", "Ascension Island", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bangladesh", "Barbados", "Barbuda", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegowina", "Botswana", "Brazil", "British Virgin Islands", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde Islands", "Cayman Islands", "Central African Republic", "Chad", "Chatham Island", "Chile", "China", "Christmas Island", "Cocos-Keeling Islands", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Cuba", "Croatia", "Curacao", "Cyprus", "Czech Republic", "Denmark", "Diego Garcia", "Dominica", "Dominican Republic", "D'Jibouti", "Easter Island", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Faroe Islands", "Falkland Islands", "Fiji Islands", "Finland", "France", "French Antilles", "French Giuana", "French Polynesia", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Grenadine Islands", "Guadalupe", "Guam", "Guantanamo Bay (Cuba)", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea (Republic of)", "Kuwait", "Kyrgyz Republic", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritus", "Mayotte Island", "Mexico", "Micronesia", "Midway Island","Moldova (Republic of)", "Monaco", "Mongolia", "Montserat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "Nevis", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Marianas Islands", "Norway", "Oman", "Pakistan", "Palau", "Palestine", "Panama", "Papua New Guinea", "Paraguay","Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Réunion Island", "Romania", "Russian Federation", "Rwanda", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "Spain", "Sri Lanka", "St. Helena", "St. Kitts", "St. Lucia", "St. Pierre et Miquelon", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Tahiti", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tokelau Islands", "Tonga Islands", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "US Virgin Islands", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Wake Island", "Wallis and Futuna Islands", "Western Samoa","Yemen-Arab Republic", "Zambia", "Zanzibar", "Zimbawe" };
		public string[] languages = { "Abkhazian", "Afar", "Afrikaans", "Albanian", "Amharic", "Arabic", "Armenian", "Assamese", "Aymara", "Azerbaijani", "Bashkir", "Basque", "Belarusian", "Bengali", "Bhutani", "Bihari", "Bislama", "Bosnian", "Breton", "Bulgarian", "Burmese", "Catalan", "Chinese (Cantonese)", "Chinese (Mandarin)", "Chinese (other)", "Corsican", "Croatian", "Czech", "Danish", "Dhivehi", "Dutch", "English", "Esperanto", "Estonian", "Faroese", "Farsi", "Fiji", "Finnish", "French", "Frisian", "Galician", "Ganda", "Georgian", "German", "Gree", "Greenlandic", "Guarani", "Gujarati", "Haitian Creole", "Hausa", "Hebrew", "Hindi", "Hungarian", "Icelandic", "Indonesian", "Inuktitut", "Inupiak", "Irish", "Italian", "Japanese", "Javanese", "Kannada", "Kashmiri", "Kazakh", "Khmer", "Kinyarwanda", "Kirundi", "Korean", "Kurdish", "Kyrgyz", "Laothian", "Latin", "Latvian", "Lingala", "Lithuanian", "Macedonian", "Malagasy", "Malay", "Malayalam", "Maltese", "Maori", "Marathi", "Moldavian", "Mongolian", "Nauru", "Nepali", "Norwegian (Bokmal)", "Norwegian (Nynorsk)", "Oriya", "Oromo", "Pashto/Pushto", "Polish", "Portuguese (Brazil)", "Portuguese", "Punjabi", "Quechua", "Rhaeto-Romance", "Romanian", "Russian","Samoan", "Sangho", "Sanskrit", "Scots Gaelic", "Serbian", "Serbo-Croatian", "Sesotho", "Setswana", "Shona", "Sindhi", "Sinhalese", "Siswati", "Slovak", "Slovenian", "Somali", "Spanish", "Sundanese", "Swahili", "Swedish", "Tagalog", "Tajik", "Tamil", "Tatar", "Telugu", "Thai", "Tibetan", "Tigrinya", "Tonga", "Tsonga", "Turkish", "Turkmen", "Twi", "Uighur", "Ukrainian", "Urdu", "Uzbek", "Vietnamese", "Volapuk", "Welsh", "Wolof", "Xhosa", "Yiddish", "Yiddish", "Zhuang", "Zulu" };
	}
}

