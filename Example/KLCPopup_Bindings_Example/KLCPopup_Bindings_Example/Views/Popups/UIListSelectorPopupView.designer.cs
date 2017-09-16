// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace KLCPopup_Bindings_Example
{
    [Register ("UIListSelectorPopupView")]
    partial class UIListSelectorPopupView
    {
        [Outlet]
        UIKit.UIButton CancelButton { get; set; }


        [Outlet]
        UIKit.UIButton ChooseButton { get; set; }


        [Outlet]
        UIKit.UIView ContainerView { get; set; }


        [Outlet]
        UIKit.UIView rootView { get; set; }


        [Outlet]
        UIKit.UITableView TableView { get; set; }


        [Outlet]
        UIKit.UILabel Title { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CancelButton != null) {
                CancelButton.Dispose ();
                CancelButton = null;
            }

            if (ChooseButton != null) {
                ChooseButton.Dispose ();
                ChooseButton = null;
            }

            if (ContainerView != null) {
                ContainerView.Dispose ();
                ContainerView = null;
            }

            if (rootView != null) {
                rootView.Dispose ();
                rootView = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }

            if (Title != null) {
                Title.Dispose ();
                Title = null;
            }
        }
    }
}