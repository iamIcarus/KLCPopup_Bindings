// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace KLCPopup_Bindings_Example
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UILabel ItemSelectedLabel { get; set; }

		[Outlet]
		UIKit.UIButton PressMeButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (PressMeButton != null) {
				PressMeButton.Dispose ();
				PressMeButton = null;
			}

			if (ItemSelectedLabel != null) {
				ItemSelectedLabel.Dispose ();
				ItemSelectedLabel = null;
			}
		}
	}
}
