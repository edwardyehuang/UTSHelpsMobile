using System;
using Xamarin.Forms;

namespace UTSHelps.UI
{
	public class TextLabelCell : ViewCell
	{
		public static readonly BindableProperty LabelProperty =
			BindableProperty.Create ("Label", typeof(string), typeof(TextLabelCell), "");

		public string Label {
			get { return (string)GetValue (LabelProperty); }
			set { SetValue (LabelProperty, value); }
		}

		public static readonly BindableProperty TextProperty =
			BindableProperty.Create ("Text", typeof(string), typeof(TextLabelCell), "");

		public string Text {
			get { return (string)GetValue (TextProperty); }
			set { SetValue (TextProperty, value); }
		}

		public bool HasArrow { get; set;} = false;
		public TextAlignment XAlign { get; set; } = TextAlignment.Start;

		public Color BackgroundColor { get; set;} = new Color(1, 1, 1, 0.2);
		public Color LabelColor { get; set;} = Color.Black;

		public bool IsVisible { get; set; } = true;

		public bool HasLabelShadow { get; set; } = false;


		public TextLabelCell ()
		{
			

		}
	}
}

