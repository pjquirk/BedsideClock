using System;

namespace BedsideClock.Model
{
	public class Options
	{
		public bool ShowSeconds { get; set; }

		public bool Use24Hour { get; set; }

		public string Font { get; set; }

		public Options()
		{
			ShowSeconds = false;
			Use24Hour = false;
			Font = null;
		}
	}
}

