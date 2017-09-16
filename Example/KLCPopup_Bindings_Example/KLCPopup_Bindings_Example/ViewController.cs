using System;
using System.Collections.Generic;
using UIKit;
using KLCPopup_Bindings;
using CoreGraphics;

namespace KLCPopup_Bindings_Example
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			ItemSelectedLabel.SizeToFit ();
			PressMeButton.TouchUpInside += PressMeButton_TouchUpInside;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		List<CheckBoxItem<int>> GetDummyList ()
		{
			var DummyList = new List<CheckBoxItem<int>> ();
			DummyList.Add (new CheckBoxItem<int> () { Title = "Washington, D.C.", Value = 1 });
			DummyList.Add (new CheckBoxItem<int> () { Title = "London", Value = 2 });
			DummyList.Add (new CheckBoxItem<int> () { Title = "Athens", Value = 3 });
			DummyList.Add (new CheckBoxItem<int> () { Title = "Berlin", Value = 4 });
			DummyList.Add (new CheckBoxItem<int> () { Title = "Paris", Value = 5 });
			DummyList.Add (new CheckBoxItem<int> () { Title = "Cairo", Value = 6 });

			return DummyList;
		}

		void PressMeButton_TouchUpInside (object sender, EventArgs e)
		{
			float max = Math.Max ((float)View.Frame.Width, (float)View.Frame.Height);
			var ListSelectorPopupView = new UIListSelectorPopupView (new CGRect (0, 0, max, max));
			var KLCPopupDialog = KLCPopup.PopupWithContentView (ListSelectorPopupView, KLCPopupShowType.BounceIn, KLCPopupDismissType.BounceOut, KLCPopupMaskType.Dimmed, false, false);


			ListSelectorPopupView.ValueType = typeof (int); // Set the time of return value of the check list
			ListSelectorPopupView.KLCPopupDialog = KLCPopupDialog; // Assing the dialog so we can dismiss later
			ListSelectorPopupView.TitleLabel.Text = "Select Answer"; // Set the title
			ListSelectorPopupView.ListTableView.Source = new ListItemCheckBoxSource<int> (GetDummyList ()); // List of items

			ListSelectorPopupView.OnItemSelected += (object model1) => {

				var res = model1 as CheckBoxItem<int>;

				ItemSelectedLabel.Text = string.Format ("Selected Item\nTitle: {0}\nValue: {1}", res.Title, res.Value);
				KLCPopupDialog.Dismiss (true);
			};

			KLCPopupDialog.ShowWithLayout (new KLCPopupLayout () { horizontal = KLCPopupHorizontalLayout.Center, vertical = KLCPopupVerticalLayout.Center });
		}

}
}
