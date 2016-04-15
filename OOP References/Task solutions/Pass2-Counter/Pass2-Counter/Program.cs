using System;

namespace Pass2Counter
{
	class MainClass
	{
		public static void PrintCounters(ref Counter[] counters)
		{
			Counter c;

			for (int i = 0; i < counters.Length; i++)
			{
				c = counters [i];
				Console.WriteLine("{0} is {1}", c.Name, c.Value);
			}
		}

		public static void Main (string[] args)
		{
			Counter[] myCounters = new Counter[3];
			int i;
			myCounters[0] = new Counter("Counter 1");
			myCounters[1] = new Counter("Counter 2");
			myCounters[2] = myCounters[0];

			for (i = 0; i < 5; i++) 
			{
				myCounters [0].Increment ();
			}

			for (i = 0; i < 5; i++) 
			{
				myCounters [1].Increment ();
			}

			MainClass.PrintCounters (ref myCounters);

			myCounters [2].Reset ();
			MainClass.PrintCounters (ref myCounters);
		}
	}
}
