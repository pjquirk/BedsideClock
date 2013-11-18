using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace BedsideClock.Options
{
	public class OptionsRootElement : RootElement
	{
		public OptionsRootElement()
			: base("Bedside Clock")
		{
			Add(new Section("Clock Display") {
				new StringElement("Color", "Green"),
				new StringElement("Font", "Helvetica"),
				new BooleanElement("24 hour", false),
				new BooleanElement("Seconds", false)
			});
			Add(new Section("Brightness") {
				new FloatElement(null, null, 0.5f)
			});
		}
	}
}