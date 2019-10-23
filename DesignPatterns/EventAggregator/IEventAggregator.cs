using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.EventAggregator
{
    public interface IEventAggregator
    {
        void Subscribe(object subscriber);
        void Publish<TEvent>(TEvent eventToPublish);
    }

    public class SimpleEventAggregator : IEventAggregator
    {
        Dictionary<Type, List<WeakReference>> EventSubscribers { get; } = new Dictionary<Type, List<WeakReference>>();

        object Lock { get; } = new object();

        public void Publish<TEvent>(TEvent eventToPublish)
        {
            var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEvent));
            var subscribers = GetSubscribers(subscriberType);
            var subscribersToRemove = new List<WeakReference>();

            foreach (var weakSubscriber in subscribers)
            {
                if (weakSubscriber.IsAlive)
                {
                    var subscriber = (ISubscriber<TEvent>?)weakSubscriber.Target;

                    // Publisher and subscriber may be living in different threads,
                    // so use SynchronizationContext to ensure that everything gets marshalled to the right thread.
                    var syncContext = SynchronizationContext.Current;
                    if (syncContext == null)
                        syncContext = new SynchronizationContext();

                    syncContext.Post(s => subscriber?.OnEvent(eventToPublish), null);
                }
                else
                {
                    subscribersToRemove.Add(weakSubscriber);
                }
            }

            if (subscribersToRemove.Any())
            {
                lock (Lock)
                {
                    subscribersToRemove.ForEach(s => subscribers.Remove(s));
                }
            }
        }

        public void Subscribe(object subscriber)
        {
            lock (Lock)
            {
                var subscriberTypes = subscriber.GetType().GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubscriber<>));
                var weakReference = new WeakReference(subscriber);
                foreach (var subscriberType in subscriberTypes)
                {
                    var subscribers = GetSubscribers(subscriberType);
                    subscribers.Add(weakReference);
                }
            }
        }

        List<WeakReference> GetSubscribers(Type subscriberType)
        {
            lock (Lock)
            {
                if (!EventSubscribers.TryGetValue(subscriberType, out List<WeakReference>? subscribers))
                {
                    subscribers = new List<WeakReference>();
                    EventSubscribers.Add(subscriberType, subscribers);
                }

                return subscribers;
            }
        }
    }
}
