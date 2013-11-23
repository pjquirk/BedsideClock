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
			textView = new UILabel { 
				BackgroundColor = UIColor.Black,
				TextColor = UIColor.Green,
				Text = "12:00",
				TextAlignment = UITextAlignment.Center,
				UserInteractionEnabled = true,
				AdjustsFontSizeToFitWidth = true
			};
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
			textView.Text = DateTime.Now.ToString("h:mm:ss");
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
			UpdateClockText();
			NavigationController.SetNavigationBarHidden(true, animated);
			NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
			UpdateToDisplayOrientation(InterfaceOrientation);
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