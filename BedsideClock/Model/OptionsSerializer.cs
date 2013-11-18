using System;

namespace BedsideClock.Model
{
	public class OptionsSerializer
	{
		public OptionsSerializer()
		{
		}

		public Options Load()
		{
			return new Options();
		}

		public void Save(Options options)
		{
			// do nothing for now
		}
	}
}

