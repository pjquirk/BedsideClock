using System;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Drawing;
using System.Collections.Generic;

namespace BedsideClock.Options
{
	public class OptionsRootElement : RootElement
	{
		readonly BooleanElement use24Hour;
		readonly BooleanElement showSeconds;
		readonly RadioGroup fontGroup;
		readonly IList<string> customFontNames;
		readonly IList<string> standardFontNames;

		public OptionsRootElement(Model.Options options)
			: base("Bedside Clock")
		{
			customFontNames = new string[] { "LCDMono" };
			standardFontNames = UIFont.FamilyNames.OrderBy(f => f).ToArray();

			use24Hour = new BooleanElement("24 hour", options.Use24Hour);
			showSeconds = new BooleanElement("Seconds", options.ShowSeconds);
			// TODO: Make this "selected" value come from the options
			fontGroup = new RadioGroup(0);

			var customFontSection = new Section("Custom");
			customFontSection.AddAll(customFontNames.Select(f => new FontEntryElement(f)));

			var fontSection = new Section("Standard Fonts");
			fontSection.AddAll(standardFontNames.Select(f => new FontEntryElement(f)));

			Add(new Section("Clock Display") {
				new StringElement("Color", "Green"),
				new RootElement("Font", fontGroup) { customFontSection, fontSection },
				use24Hour,
				showSeconds
			});
			Add(new Section("Brightness") {
				new FloatElement(null, null, 0.5f)
			});
		}

		public Model.Options GetOptions()
		{
			Model.Options options = new Model.Options {
				Use24Hour = use24Hour.Value,
				ShowSeconds = showSeconds.Value,
			};

			if (fontGroup.Selected >= 0)
			{
				if (fontGroup.Selected < customFontNames.Count)
					options.Font = customFontNames[fontGroup.Selected];
				else
					options.Font = standardFontNames[fontGroup.Selected - customFontNames.Count];
			}

			return options;
		}
	}
}