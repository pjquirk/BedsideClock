using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using BedsideClock.Model;

namespace BedsideClock
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController rootViewController;
		Options.OptionsViewController optionsViewController;
		Model.Options options;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			LoadOptions();

			// create a new window instance based on the screen size
			window = new UIWindow(UIScreen.MainScreen.Bounds);

			optionsViewController = new Options.OptionsViewController(options);
			rootViewController = new UINavigationController();
			rootViewController.PushViewController(optionsViewController, false);

			var clockButton = new UIBarButtonItem("Clock", UIBarButtonItemStyle.Plain, ShowClock);
			optionsViewController.NavigationItem.RightBarButtonItem = clockButton;

			window.RootViewController = rootViewController;
			
			// make the window visible
			window.MakeKeyAndVisible();
			
			return true;
		}

		public override void DidEnterBackground(UIApplication application)
		{
			SaveOptions();
		}

		void ShowClock(object sender, EventArgs eventArgs)
		{
			var clockViewController = new Clock.ClockViewController();
			rootViewController.PushViewController(clockViewController, true);
		}

		void SaveOptions()
		{
			OptionsSerializer serializer = new OptionsSerializer();
			serializer.Save(optionsViewController.GetOptions());
		}

		void LoadOptions()
		{
			OptionsSerializer serializer = new OptionsSerializer();
			options = serializer.Load();
		}
	}
}