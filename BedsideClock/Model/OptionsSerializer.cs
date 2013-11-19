using System;
using MonoTouch.Foundation;

namespace BedsideClock.Model
{
	public class OptionsSerializer
	{
		public Options Load()
		{
			var defaults = NSUserDefaults.StandardUserDefaults;
			return new Options {
				Use24Hour = defaults.BoolForKey("Use24Hour"),
				ShowSeconds = defaults.BoolForKey("ShowSeconds")
			};
		}

		public void Save(Options options)
		{
			var defaults = NSUserDefaults.StandardUserDefaults;
			defaults.SetBool(options.Use24Hour, "Use24Hour");
			defaults.SetBool(options.ShowSeconds, "ShowSeconds");
			defaults.Synchronize();
		}
	}
}