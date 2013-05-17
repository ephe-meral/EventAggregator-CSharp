/**
 * For copyright information see the LICENSE document.
 */

using System;
using EpheMeral.EventDrivenDesign;

namespace Test
{
	public class TestHandlers : IRegisterable
	{

		String name;


		public TestHandlers(String name)
		{
			this.name = name;
		}


		public void RegisterMeWith(IEventAggregator aggregator)
		{
			aggregator.Register<SomeEvent>(OnSampleEvent);
			aggregator.Register<SomeOtherEvent>(OnOtherEvent);
		}


		public void OnSampleEvent(SomeEvent evt)
		{
			Console.WriteLine(name + " got the sample event with message: [ Foo = " + evt.Foo + " ]");
		}


		public void OnOtherEvent(SomeOtherEvent evt)
		{
			Console.WriteLine(name + " got the other sample event with message: [ Bar = " + evt.Bar + " ]");
		}
	}
}

