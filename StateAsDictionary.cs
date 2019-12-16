using System;
using System.Collections.Generic;

namespace DesignPatterns
{
	public enum State
	{
		OffHook,
		Connecting,
		Connected,
		OnHold
	}

	public enum Trigger
	{
		CallDialed,
		HangUp,
		CallConnected,
		PlacedOnHold,
		TakenOffHold,
		LeftMessage
	}

	class StateAsDictionary
	{
		private static Dictionary<State, List<(Trigger, State)>> rules =
			new Dictionary<State, List<(Trigger, State)>>
			{
				[State.OffHook] = new List<(Trigger, State)> {
					(Trigger.CallDialed, State.Connecting)
				},
				[State.Connecting] = new List<(Trigger, State)>
				{
					(Trigger.CallConnected, State.Connected),
					(Trigger.HangUp, State.OffHook)
				},
				[State.Connected] = new List<(Trigger, State)>
				{
					(Trigger.PlacedOnHold, State.OnHold),
					(Trigger.HangUp, State.OffHook),
					(Trigger.LeftMessage, State.OffHook)
				},
				[State.OnHold] = new List<(Trigger, State)>
				{
					(Trigger.TakenOffHold, State.Connected),
					(Trigger.HangUp, State.OffHook)
				}
			};

		static void Main(string[] args)
		{
			var state = State.OffHook;

			while (true)
			{
				Console.WriteLine("We are now in {0}", state);
				Console.WriteLine("Select trigger:");

				for (int i = 0; i < rules[state].Count; i++)
				{
					var (n, _) = rules[state][i];
					Console.WriteLine("{0}: {1}", i, n);
				}

				var input = int.Parse(Console.ReadLine());
				var (_, s) = rules[state][input];
				state = s;
			}
		}
	}
}
