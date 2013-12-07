using System;
using MonoTouch.UIKit;

namespace BedsideClock.Util
{
	public static class FontUtil
	{
		public static float GetFontSizeToFitWidth(string fontName, float width)
		{
			UIFont font = UIFont.FromName(fontName, 100);
			UIStringAttributes attributes = new UIStringAttributes();
			float measuredWidth = 0;
			float min = 10;
			float max = 1000;
			float fontSize = (max - min) / 2.0f + min;

			while (Math.Abs(measuredWidth - width) > 20)
			{
				fontSize = (max - min) / 2.0f + min;
				attributes.Font = font.WithSize(fontSize);
				measuredWidth = NSStringDrawing.GetSizeUsingAttributes((MonoTouch.Foundation.NSString)"00:00:00", attributes).Width;
				if (measuredWidth < width)
					min = fontSize;
				else
					max = fontSize;
			}

			if (measuredWidth > width)
				fontSize = min;

			return fontSize;
		}
	}
}