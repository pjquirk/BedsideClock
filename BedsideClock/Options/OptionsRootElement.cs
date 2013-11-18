using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace BedsideClock.Options
{
	public class OptionsRootElement : RootElement
	{
		public OptionsRootElement(Model.Options options)
			: base("Bedside Clock")
		{
			Add(new Section("Clock Display") {
				new StringElement("Color", "Green"),
				new StringElement("Font", "Helvetica"),
				new BooleanElement("24 hour", options.Use24Hour),
				new BooleanElement("Seconds", options.ShowSeconds)
			});
			Add(new Section("Brightness") {
				new FloatElement(null, null, 0.5f)
			});
		}
	}
}