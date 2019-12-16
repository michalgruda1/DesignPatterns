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

	class StateDesignPattern
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
			
		}
	}
}
