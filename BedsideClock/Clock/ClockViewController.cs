using System;
using MonoTouch.UIKit;

namespace BedsideClock.Clock
{
	public class ClockViewController : UIViewController
	{
		public ClockViewController()
		{
			var textView = new UILabel { 
				BackgroundColor = UIColor.Black,
				TextColor = UIColor.Green,
				Text = "12:00",
				TextAlignment = UITextAlignment.Center,
				Frame = UIScreen.MainScreen.Bounds,
				UserInteractionEnabled = true
			};
			textView.AddGestureRecognizer(new UITapGestureRecognizer(ToggleNavigationBarVisibility));

			Add(textView);
		}

		public override void ViewWillAppear(bool animated)
		{
			NavigationController.SetNavigationBarHidden(true, animated);
			NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
			base.ViewWillAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			NavigationController.NavigationBar.BarStyle = UIBarStyle.Default;
			base.ViewWillDisappear(animated);
		}

		void ToggleNavigationBarVisibility()
		{
			NavigationController.SetNavigationBarHidden(!NavigationController.NavigationBarHidden, true);
		}
	}
}