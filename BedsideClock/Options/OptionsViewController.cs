using System;
using MonoTouch.Dialog;

namespace BedsideClock.Options
{
	public class OptionsViewController : DialogViewController
	{
		static OptionsRootElement root;

		public OptionsViewController()
			: base(root = new OptionsRootElement())
		{
		}
	}
}