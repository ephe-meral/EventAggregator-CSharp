/**
 * For copyright information see the LICENSE document.
 */

using System;
using EpheMeral.EventDrivenDesign;

namespace Test
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Starting the tests...");

			// create the event aggregator and the object
			// that contains the handler methods
			var aggr = new EventAggregator();
			//var aggr = new EventAggregator.ConcurrentEventAggregator();
			var handlerObj1 = new TestHandlers("1st handlers");
			var handlerObj2 = new TestHandlers("2nd handlers");

			// call the convenience method to register the handlers
			// with the aggregator
			aggr.Register(handlerObj1);
			aggr.Register(handlerObj2);

			// create some mock events and set their sample values
			var fooEvt = new SomeEvent();
			var barEvt = new SomeOtherEvent();

			fooEvt.Foo = 1337;
			barEvt.Bar = "Hello";

			// trigger the events: 1st time
			aggr.Trigger(fooEvt);
			aggr.Trigger(barEvt);

			fooEvt.Foo = 42;
			barEvt.Bar = "Blubb";

			// trigger the events: 2st time
			aggr.Trigger(barEvt);
			aggr.Trigger(fooEvt);

			Console.WriteLine("Finished running the tests.");
		}
	}
}
