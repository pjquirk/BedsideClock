using System;
using MonoTouch.Dialog;

namespace BedsideClock.Options
{
	public class OptionsViewController : DialogViewController
	{
		static OptionsRootElement root;

		public OptionsViewController(Model.Options options)
			: base(root = new OptionsRootElement(options))
		{
		}

		public Model.Options GetOptions()
		{
			return root.GetOptions();
		}
	}
}