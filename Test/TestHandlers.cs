using System;
using EventAggregator;

namespace Test
{
	public class TestHandlers : IRegisterable
	{

		public void RegisterMeWith(IEventAggregator aggregator)
		{
			aggregator.Register<SomeEvent>(OnSampleEvent);
			aggregator.Register<SomeOtherEvent>(OnOtherEvent);
		}


		public void OnSampleEvent(SomeEvent evt)
		{
			Console.WriteLine("Got the sample event with message: [ Foo = " + evt.Foo + " ]");
		}


		public void OnOtherEvent(SomeOtherEvent evt)
		{
			Console.WriteLine("Got the other event with message: [ Bar = " + evt.Bar + " ]");
		}
	}
}

