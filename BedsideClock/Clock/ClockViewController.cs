using System;
using MonoTouch.UIKit;
using System.Timers;

namespace BedsideClock.Clock
{
	public class ClockViewController : UIViewController
	{
		readonly UILabel textView;
		readonly Timer timer;
		readonly Model.Options options;

		public ClockViewController(BedsideClock.Model.Options options)
		{
			this.options = options;
			textView = new UILabel { 
				BackgroundColor = UIColor.Black,
				TextColor = UIColor.Green,
				Text = "12:00",
				TextAlignment = UITextAlignment.Center,
				UserInteractionEnabled = true,
				AdjustsFontSizeToFitWidth = true
			};

			if (options.Font != null)
				textView.Font = UIFont.FromName(options.Font, 200);
			else
				textView.Font = textView.Font.WithSize(200);
			textView.AddGestureRecognizer(new UITapGestureRecognizer(ToggleNavigationBarVisibility));

			Add(textView);

			timer = new Timer(1000);
			timer.AutoReset = true;
			timer.Elapsed += HandleElapsed;
			timer.Enabled = true;
		}

		void HandleElapsed(object sender, ElapsedEventArgs e)
		{
			textView.BeginInvokeOnMainThread(UpdateClockText);
		}

		void UpdateClockText()
		{
			string format;

			format = options.Use24Hour ? "H:mm" : "h:mm";
			if (options.ShowSeconds)
				format += ":ss";

			textView.Text = DateTime.Now.ToString(format);
		}

		void UpdateToDisplayOrientation(UIInterfaceOrientation interfaceOrientation)
		{
			switch (interfaceOrientation)
			{
				case UIInterfaceOrientation.LandscapeLeft:
				case UIInterfaceOrientation.LandscapeRight:
					textView.Frame = new System.Drawing.RectangleF(0, 0, UIScreen.MainScreen.Bounds.Height, UIScreen.MainScreen.Bounds.Width);
					break;
				case UIInterfaceOrientation.Portrait:
				case UIInterfaceOrientation.PortraitUpsideDown:
					textView.Frame = UIScreen.MainScreen.Bounds;
					break;
				default:
					break;
			}
		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			UpdateToDisplayOrientation(toInterfaceOrientation);
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.AllButUpsideDown;
		}

		public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation()
		{
			return UIInterfaceOrientation.LandscapeLeft;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			UpdateClockText();
			NavigationController.SetNavigationBarHidden(true, animated);
			NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
			UpdateToDisplayOrientation(InterfaceOrientation);

			// Sets the brightness: 0 - dimmest, 1 - brightest
			UIScreen.MainScreen.Brightness = 0.5f;
			// If true, this will overlay a semi-transparent window, making everything dimmer
			UIScreen.MainScreen.WantsSoftwareDimming = true;
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			NavigationController.NavigationBar.BarStyle = UIBarStyle.Default;
		}

		void ToggleNavigationBarVisibility()
		{
			NavigationController.SetNavigationBarHidden(!NavigationController.NavigationBarHidden, true);
		}
	}
}