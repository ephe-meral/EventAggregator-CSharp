/**
 * For copyright information see the LICENSE document.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace EventAggregator
{
	/// <summary>
	/// EventAggregator class.
	/// This class represents a multi threaded IEventAggregator implementation
	/// that uses a minimum of reflection and the EventHandler generic delegate type.
	/// This class will fork a triggered event into multiple tasks, each of them being
	/// defined by one of the registered handlers.
	/// For more information see IEventAggregator.
	/// </summary>
	public class ConcurrentEventAggregator : IEventAggregator
	{
		
		IDictionary<Type, IList<EventHandler<IEvent>>> handlers;


		public ConcurrentEventAggregator()
		{
			handlers = new ConcurrentDictionary<Type, IList<EventHandler<IEvent>>>();
		}


		public void Register(IRegisterable registerable)
		{
			registerable.RegisterMeWith(this);
		}


		public void Register<T>(EventHandler<T> handler) where T : IEvent
		{
			if (!handlers.ContainsKey(typeof(T)))
			{
				handlers[typeof(T)] = new List<EventHandler<IEvent>>();
			}

			var handlerList = handlers[typeof(T)];

			handlerList.Add(evt => handler((T)evt));
		}


		public void Trigger(IEvent evt)
		{
			IList<EventHandler<IEvent>> handlerList;

			if (handlers.TryGetValue(evt.GetType(), out handlerList))
			{
				Parallel.ForEach (handlerList, handler =>
				{
					handler.Invoke(evt);
				});
			}
		}
	}
}

