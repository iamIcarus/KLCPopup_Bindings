using System;
using Foundation;
using UIKit;
using ObjCRuntime;
using System.Collections.Generic;
using System.Drawing;
using CoreGraphics;
using KLCPopup_Bindings;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace KLCPopup_Bindings_Example
{
	public partial class UIListSelectorPopupView : UIView
	{
		public Type ValueType { get; set; }

		public delegate void ItemClickedEventHandler (object model);

		public event ItemClickedEventHandler OnItemSelected;

		string CellNibName = "ListItemCheckBox";

		public KLCPopup KLCPopupDialog { get; set; }

		public UIView RootView { get { return rootView; } set { rootView = value; } }
	
		public UILabel TitleLabel { get { return Title; } set { Title = value;} }

		public UIButton Choose { get { return ChooseButton; } set { ChooseButton = value; } }

		public UIButton Cancel { get { return CancelButton; } set { CancelButton = value; }  }

		public UITableView ListTableView { get { return TableView; } set { TableView = value; } }

		public UIListSelectorPopupView (IntPtr handle) : base (handle)
        {
			
        }

		public UIListSelectorPopupView (CGRect frame) : base (frame)
		{
			//Loading the XIB file to be used for this UIView subclass
			var array = NSBundle.MainBundle.LoadNib ("UIListSelectorPopupView", this, null);
			var view = Runtime.GetNSObject (array.ValueAt (0)) as UIView;

			var subViewFrame = view.Frame;
			subViewFrame.Width = this.Frame.Width;
			subViewFrame.Height = this.Frame.Height;
			view.Frame = subViewFrame;



			ConfigureView ();
			//Adding View loaded from Xib to placeholder view
			AddSubview (view);

		}

		void ConfigureView ()
		{
			// Set Rounded corners
			ContainerView.Layer.CornerRadius = 5;
			ContainerView.Layer.MasksToBounds = true;

			// Add Shadow
			ContainerView.Layer.MasksToBounds = false;
			ContainerView.Layer.ShadowOffset = new CGSize (0, 0);
			ContainerView.Layer.ShadowRadius = 5;
			ContainerView.Layer.ShadowOpacity = 0.5f;

			TableView.RegisterNibForCellReuse (UINib.FromName (CellNibName, NSBundle.MainBundle), CellNibName);
			TableView.AllowsSelection = false;

			Cancel.TouchUpInside += Cancel_TouchUpInside;
			Choose.TouchUpInside += Choose_TouchUpInside;

		}

		void Cancel_TouchUpInside (object sender, EventArgs e)
		{
			if(KLCPopupDialog!=null)
				KLCPopupDialog.Dismiss (true);
		}

		void Choose_TouchUpInside (object sender, EventArgs e)
		{

			if (TableView.Source == null)
				return;


			Type SourceType = TableView.Source.GetType ();
			MethodInfo GetCheckedMethod = SourceType.GetMethod ("GetChecked");
			var CheckedItem = GetCheckedMethod.Invoke (TableView.Source, null) ;


			ItemClickedEventHandler temp = OnItemSelected;

			if (temp != null)
				temp ((object)CheckedItem);
		}
	}
}