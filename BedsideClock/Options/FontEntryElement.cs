using System;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Drawing;

namespace BedsideClock.Options
{

	public class FontEntryElement : MonoTouch.Dialog.RadioElement
	{
		public FontEntryElement(string caption, string group, string fontName) : base(caption, group)
		{
			this.fontName = fontName;
		}

		public override UITableViewCell GetCell(UITableView tableView)
		{
			var cell = base.GetCell(tableView);
			cell.TextLabel.Font = UIFont.FromName(fontName, 14);
			return cell;
		}

		string fontName;
	}
}