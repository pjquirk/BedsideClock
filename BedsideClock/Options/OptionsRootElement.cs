using System;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Drawing;

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

			var customFontSection = new Section("Custom");
			customFontSection.Add(new FontEntryElement("10:27", "font", "LCDMono"));

			var fontSection = new Section("Standard Fonts");
			fontSection.AddAll(UIFont.FamilyNames.OrderBy(f => f).Select(f => new FontEntryElement("10:27", "font", f)));

			Add(new Section("Clock Display") {
				new StringElement("Color", "Green"),
				new RootElement("Font", new RadioGroup("font", 0)) { customFontSection, fontSection },
				use24Hour,
				showSeconds
			});
			Add(new Section("Brightness") {
				new FloatElement(null, null, 0.5f)
			});
		}

		public Model.Options GetOptions()
		{
			return new Model.Options {
				Use24Hour = use24Hour.Value,
				ShowSeconds = showSeconds.Value
			};
		}
	}
}