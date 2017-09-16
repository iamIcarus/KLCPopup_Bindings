using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace KLCPopup_Bindings
{

	//[Static]
	[//Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const KLCPopupLayout KLCPopupLayoutCenter;
		[Field ("KLCPopupLayoutCenter", "__Internal")]
		KLCPopupLayout KLCPopupLayoutCenter { get; }
	}

	// @interface KLCPopup : UIView
	[BaseType (typeof (UIView))]
	public interface KLCPopup
	{
		// @property (nonatomic, strong) UIView * contentView;
		[Export ("contentView", ArgumentSemantic.Strong)]
		UIView ContentView { get; set; }

		// @property (assign, nonatomic) KLCPopupShowType showType;
		[Export ("showType", ArgumentSemantic.Assign)]
		KLCPopupShowType ShowType { get; set; }

		// @property (assign, nonatomic) KLCPopupDismissType dismissType;
		[Export ("dismissType", ArgumentSemantic.Assign)]
		KLCPopupDismissType DismissType { get; set; }

		// @property (assign, nonatomic) KLCPopupMaskType maskType;
		[Export ("maskType", ArgumentSemantic.Assign)]
		KLCPopupMaskType MaskType { get; set; }

		// @property (assign, nonatomic) CGFloat dimmedMaskAlpha;
		[Export ("dimmedMaskAlpha")]
		nfloat DimmedMaskAlpha { get; set; }

		// @property (assign, nonatomic) BOOL shouldDismissOnBackgroundTouch;
		[Export ("shouldDismissOnBackgroundTouch")]
		bool ShouldDismissOnBackgroundTouch { get; set; }

		// @property (assign, nonatomic) BOOL shouldDismissOnContentTouch;
		[Export ("shouldDismissOnContentTouch")]
		bool ShouldDismissOnContentTouch { get; set; }

		// @property (copy, nonatomic) void (^didFinishShowingCompletion)();
		[Export ("didFinishShowingCompletion", ArgumentSemantic.Copy)]
		Action DidFinishShowingCompletion { get; set; }

		// @property (copy, nonatomic) void (^willStartDismissingCompletion)();
		[Export ("willStartDismissingCompletion", ArgumentSemantic.Copy)]
		Action WillStartDismissingCompletion { get; set; }

		// @property (copy, nonatomic) void (^didFinishDismissingCompletion)();
		[Export ("didFinishDismissingCompletion", ArgumentSemantic.Copy)]
		Action DidFinishDismissingCompletion { get; set; }

		// +(KLCPopup *)popupWithContentView:(UIView *)contentView;
		[Static]
		[Export ("popupWithContentView:")]
		KLCPopup PopupWithContentView (UIView contentView);

		// +(KLCPopup *)popupWithContentView:(UIView *)contentView showType:(KLCPopupShowType)showType dismissType:(KLCPopupDismissType)dismissType maskType:(KLCPopupMaskType)maskType dismissOnBackgroundTouch:(BOOL)shouldDismissOnBackgroundTouch dismissOnContentTouch:(BOOL)shouldDismissOnContentTouch;
		[Static]
		[Export ("popupWithContentView:showType:dismissType:maskType:dismissOnBackgroundTouch:dismissOnContentTouch:")]
		KLCPopup PopupWithContentView (UIView contentView, KLCPopupShowType showType, KLCPopupDismissType dismissType, KLCPopupMaskType maskType, bool shouldDismissOnBackgroundTouch, bool shouldDismissOnContentTouch);

		// +(void)dismissAllPopups;
		[Static]
		[Export ("dismissAllPopups")]
		void DismissAllPopups ();

		// -(void)show;
		[Export ("show")]
		void Show ();

		// -(void)showWithLayout:(KLCPopupLayout)layout;
		[Export ("showWithLayout:")]
		void ShowWithLayout (KLCPopupLayout layout);

		// -(void)showWithDuration:(NSTimeInterval)duration;
		[Export ("showWithDuration:")]
		void ShowWithDuration (double duration);

		// -(void)showWithLayout:(KLCPopupLayout)layout duration:(NSTimeInterval)duration;
		[Export ("showWithLayout:duration:")]
		void ShowWithLayout (KLCPopupLayout layout, double duration);

		// -(void)showAtCenter:(CGPoint)center inView:(UIView *)view;
		[Export ("showAtCenter:inView:")]
		void ShowAtCenter (CGPoint center, UIView view);

		// -(void)showAtCenter:(CGPoint)center inView:(UIView *)view withDuration:(NSTimeInterval)duration;
		[Export ("showAtCenter:inView:withDuration:")]
		void ShowAtCenter (CGPoint center, UIView view, double duration);

		// -(void)dismiss:(BOOL)animated;
		[Export ("dismiss:")]
		void Dismiss (bool animated);

		// @property (readonly, nonatomic, strong) UIView * backgroundView;
		[Export ("backgroundView", ArgumentSemantic.Strong)]
		UIView BackgroundView { get; }

		// @property (readonly, nonatomic, strong) UIView * containerView;
		[Export ("containerView", ArgumentSemantic.Strong)]
		UIView ContainerView { get; }

		// @property (readonly, assign, nonatomic) BOOL isBeingShown;
		[Export ("isBeingShown")]
		bool IsBeingShown { get; }

		// @property (readonly, assign, nonatomic) BOOL isShowing;
		[Export ("isShowing")]
		bool IsShowing { get; }

		// @property (readonly, assign, nonatomic) BOOL isBeingDismissed;
		[Export ("isBeingDismissed")]
		bool IsBeingDismissed { get; }

		// -(void)willStartShowing;
		[Export ("willStartShowing")]
		void WillStartShowing ();

		// -(void)didFinishShowing;
		[Export ("didFinishShowing")]
		void DidFinishShowing ();

		// -(void)willStartDismissing;
		[Export ("willStartDismissing")]
		void WillStartDismissing ();

		// -(void)didFinishDismissing;
		[Export ("didFinishDismissing")]
		void DidFinishDismissing ();
	}

	// @interface KLCPopup (UIView)
	[Category]
	[BaseType (typeof (UIView))]
	public interface UIView_KLCPopup
	{
		// -(void)forEachPopupDoBlock:(void (^)(KLCPopup *))block;
		[Export ("forEachPopupDoBlock:")]
		void ForEachPopupDoBlock (Action<KLCPopup> block);

		// -(void)dismissPresentingPopup;
		[Export ("dismissPresentingPopup")]
		void DismissPresentingPopup ();
	}
}
