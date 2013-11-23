using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace BedsideClock.Options
{
	public class FontEntryElement : RadioElement
	{
		readonly string fontName;

		public FontEntryElement(string caption, string group, string fontName) : base(caption, group)
		{
			this.fontName = fontName;
		}

		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = base.GetCell(tv);
			cell.TextLabel.Font = UIFont.FromName(fontName, 14);
			return cell;
		}
	}
}