using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace KLCPopup_Bindings
{
		[Native]
	public enum KLCPopupShowType: long
	{
		None = 0,
		FadeIn,
		GrowIn,
		ShrinkIn,
		SlideInFromTop,
		SlideInFromBottom,
		SlideInFromLeft,
		SlideInFromRight,
		BounceIn,
		BounceInFromTop,
		BounceInFromBottom,
		BounceInFromLeft,
		BounceInFromRight
	}

	[Native]
	public enum KLCPopupDismissType: long
	{
		None = 0,
		FadeOut,
		GrowOut,
		ShrinkOut,
		SlideOutToTop,
		SlideOutToBottom,
		SlideOutToLeft,
		SlideOutToRight,
		BounceOut,
		BounceOutToTop,
		BounceOutToBottom,
		BounceOutToLeft,
		BounceOutToRight
	}

	[Native]
	public enum KLCPopupHorizontalLayout: long
	{
		Custom = 0,
		Left,
		LeftOfCenter,
		Center,
		RightOfCenter,
		Right
	}

	[Native]
	public enum KLCPopupVerticalLayout: long
	{
		Custom = 0,
		Top,
		AboveCenter,
		Center,
		BelowCenter,
		Bottom
	}

	[Native]
	public enum KLCPopupMaskType:long
	{
		None = 0,
		Clear,
		Dimmed
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct KLCPopupLayout
	{
		public KLCPopupHorizontalLayout horizontal;

		public KLCPopupVerticalLayout vertical;
	}

	static class CFunctions
	{
		// extern KLCPopupLayout KLCPopupLayoutMake (KLCPopupHorizontalLayout horizontal, KLCPopupVerticalLayout vertical);
		[DllImport ("__Internal")]
		static extern KLCPopupLayout KLCPopupLayoutMake (KLCPopupHorizontalLayout horizontal, KLCPopupVerticalLayout vertical);
	}

}
