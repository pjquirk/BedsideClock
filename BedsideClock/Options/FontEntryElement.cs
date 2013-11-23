using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace BedsideClock.Options
{
	public class FontEntryElement : RadioElement
	{
		readonly string fontName;

		public FontEntryElement(string fontName) : base(fontName)
		{
			this.fontName = fontName;
		}

		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = base.GetCell(tv);
			cell.TextLabel.Font = UIFont.FromName(fontName, 14);
			cell.TextLabel.Text = string.Format("{0} - 10:27", fontName);
			return cell;
		}
	}
}