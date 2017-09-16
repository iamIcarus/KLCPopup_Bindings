using System;
using System.Collections.Generic;

namespace KLCPopup_Bindings_Example
{
	public interface IListItemCheckBoxSource<T>
	{
		void SetItems (List<T> items);

		List<CheckBoxItem<T>> GetItems ();

		CheckBoxItem<T> GetChecked ();

	}
}
