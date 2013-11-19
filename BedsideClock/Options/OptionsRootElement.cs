using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace BedsideClock.Options
{
	public class OptionsRootElement : RootElement
	{
		readonly BooleanElement use24Hour;
		readonly BooleanElement showSeconds;

		public OptionsRootElement(Model.Options options)
			: base("Bedside Clock")
		{
			use24Hour = new BooleanElement("24 hour", options.Use24Hour);
			showSeconds = new BooleanElement("Seconds", options.ShowSeconds);

			Add(new Section("Clock Display") {
				new StringElement("Color", "Green"),
				new StringElement("Font", "Helvetica"),
				use24Hour,
				showSeconds
			});
			Add(new Section("Brightness") {
				new FloatElement(null, null, 0.5f)
			});
		}

		public Model.Options GetOptions()
		{
			return new BedsideClock.Model.Options {
				Use24Hour = use24Hour.Value,
				ShowSeconds = showSeconds.Value
			};
		}
	}
}