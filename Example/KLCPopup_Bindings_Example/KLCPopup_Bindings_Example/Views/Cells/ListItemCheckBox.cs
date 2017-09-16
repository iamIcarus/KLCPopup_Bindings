using System;

using Foundation;
using UIKit;

namespace KLCPopup_Bindings_Example
{
	public partial class ListItemCheckBox : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("ListItemCheckBox");

		public static readonly UINib Nib;

		public UILabel Title { get { return TitleLabel;} set { TitleLabel = value; } }

		public UIButton Checkbox { get { return CheckBoxButton; } set { CheckBoxButton = value; } }

		static ListItemCheckBox ()
		{
			Nib = UINib.FromName ("ListItemCheckBox", NSBundle.MainBundle);
		}

		protected ListItemCheckBox (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
