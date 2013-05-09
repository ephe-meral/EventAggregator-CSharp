## EventAggregator Pattern in `C#`

**This project is a lightweight C# reference implementation of the event aggregator pattern.**
  
It might not provide the exact same functionality that other implementations provide, but it should work the following way:

Any component can register any count of event handlers (In this case: delegates) with a commonly known object (The event aggregator instance) for a specific kind of event. Whenever another component triggers an event within the event aggregator, it will call all associated handlers and pass the event object to them.

This is a single threaded implementation using a minimum of reflection and built-in anonymous functions. If you encounter any problems or if you know how to make this design better, please don't hesitate to contact me or simply create a pull request.
