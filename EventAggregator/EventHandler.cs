/**
 * For copyright information see the LICENSE document.
 */

using System;

namespace EventAggregator
{
	/// <summary>
	/// EventHandler delegate.
	/// This delegate defines the signature of any event handler method.
	/// If you keep to this, you can register your own methods with the
	/// EventAggregator.
	/// </summary>
	public delegate void EventHandler<T>(T evt) where T : IEvent;
}

