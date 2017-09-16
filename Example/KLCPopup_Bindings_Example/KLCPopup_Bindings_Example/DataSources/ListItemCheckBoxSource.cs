using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace KLCPopup_Bindings_Example
{
	public class ListItemCheckBoxSource<T> : UITableViewSource, IListItemCheckBoxSource<T>
	{
		public List<CheckBoxItem<T>> Items { get; set; }


		public ListItemCheckBoxSource ( List<CheckBoxItem<T>> items)
		{
			this.Items = items as List<CheckBoxItem<T>>;
		}
		public void SetItems (List<T> items)
		{
			this.Items = items as List<CheckBoxItem<T>>;
		}
		public List<CheckBoxItem<T>>  GetItems ()
		{
			return this.Items as List<CheckBoxItem<T>>;
		}

		public CheckBoxItem<T> GetChecked ()
		{
			var Checked = Items.SingleOrDefault (x => x.IsChecked);

			return Checked;
		}


		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 46;
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return Items.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			ListItemCheckBox cell = tableView.DequeueReusableCell ("ListItemCheckBox") as ListItemCheckBox;

			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, "ListItemCheckBox") as ListItemCheckBox;
			}

			var model = Items.ElementAt (indexPath.Row);

			cell.Title.Text = model.Title;

			if (model.IsChecked)
				cell.Checkbox.SetBackgroundImage (UIImage.FromFile ("icon-checkbox-green.png"), UIControlState.Normal);
			else
				cell.Checkbox.SetBackgroundImage (UIImage.FromFile("icon-checkbox-grey.png"), UIControlState.Normal);

			cell.Checkbox.TouchUpInside -= Checkbox_TouchUpInside;
			cell.Checkbox.TouchUpInside += Checkbox_TouchUpInside;

			return cell;
		}

		void Checkbox_TouchUpInside (object sender, EventArgs e)
		{
			UIButton SenderButton = sender as UIButton;

			UITableView TableView = GetParentOfType<UITableView> (SenderButton);
			if (TableView == null)
				return;
			
			var cell = GetParentOfType<ListItemCheckBox> (SenderButton);
			if (cell == null)
				return;
			
			nint index = TableView.IndexPathForCell (cell).Row;

			var model = Items.ElementAt ((int)index);

			//For Single selection
			//----------------------
			List<NSIndexPath> RowsToUpdate = new List<NSIndexPath> ();

			// Clear previous selection 
			CheckBoxItem<T> SelectedItem = Items.SingleOrDefault (x => x.IsChecked);
			if (SelectedItem != null) {
				RowsToUpdate.Add (NSIndexPath.FromRowSection (Items.IndexOf (SelectedItem), 0));
				SelectedItem.IsChecked = false;
			}

			model.IsChecked = true;
			RowsToUpdate.Add (NSIndexPath.FromRowSection (Items.IndexOf (model), 0));

			//Using RowsToUpdate array to update with animation
			TableView.ReloadRows (RowsToUpdate.ToArray(), UITableViewRowAnimation.Fade);
			//----------------------


			//For multi-select
			//----------------------
			//model.IsChecked = !model.IsChecked;
			//TableView.ReloadRows (new NSIndexPath [] { NSIndexPath.FromRowSection (index, 0)}, UITableViewRowAnimation.Fade);
			//----------------------

		}

		public T1 GetParentOfType<T1> (object sender) where T1 : class
		{
			var b = (UIView)sender;

			var superView = b.Superview;

			while (superView != null && superView.GetType () != typeof (T1))
				superView = superView.Superview;

			return superView as T1;
		}
	}
}
