## EventAggregator Pattern in `C#`

**This project is a lightweight C# reference implementation of the event aggregator pattern.**
  
An Event Aggregator is a module that decouples the component that actually triggers an Event from the component that receives that Event. Instead of observing a specific object for a specific event, you simply observer the Event Aggregator object for that event. As an object that actually triggers the event, you simply trigger it as a message to the Event Aggregator instead of directly messaging your subscribers. The Event Aggregator associates handler functions with Event-Types so that they are being called whenever their specific event gets triggered. Generally speaking, the Event Aggregator is a special kind of mediator.

It might not provide the exact same functionality that other implementations provide, but it should work the following way:

Any component can register any count of event handlers (In this case: delegates) with a commonly known object (The event aggregator instance) for a specific kind of event. Whenever another component triggers an event within the event aggregator, it will call all associated handlers and pass the event object to them.

This is a single/multi threaded implementation using a minimum of reflection and built-in anonymous functions. If you encounter any problems or if you know how to make this design better, please don't hesitate to contact me or simply create a pull request.

The multi threaded version of the Event Aggregator uses the Task Parallel Library to execute the handlers of the events concurrently. (See the ConcurrentEventAggregator source code for more information)
