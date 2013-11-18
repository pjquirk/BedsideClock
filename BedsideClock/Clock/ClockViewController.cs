using System;
using MonoTouch.UIKit;
using System.Timers;

namespace BedsideClock.Clock
{
	public class ClockViewController : UIViewController
	{
		readonly UILabel textView;
		readonly Timer timer;

		public ClockViewController()
		{
			timer = new Timer(1000);
			timer.AutoReset = true;
			timer.Elapsed += HandleElapsed;
			textView = new UILabel { 
				BackgroundColor = UIColor.Black,
				TextColor = UIColor.Green,
				Text = "12:00",
				TextAlignment = UITextAlignment.Center,
				Frame = UIScreen.MainScreen.Bounds,
				UserInteractionEnabled = true,
				AdjustsFontSizeToFitWidth = true
			};
			textView.Font = textView.Font.WithSize(200);
			textView.AddGestureRecognizer(new UITapGestureRecognizer(ToggleNavigationBarVisibility));

			Add(textView);
			timer.Enabled = true;
		}

		void HandleElapsed(object sender, ElapsedEventArgs e)
		{
			textView.BeginInvokeOnMainThread(UpdateClockText);
		}

		void UpdateClockText()
		{
			textView.Text = DateTime.Now.ToString("h:mm:ss");
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