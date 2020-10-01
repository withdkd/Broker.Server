using System;
using System.Collections.Generic;

namespace Broker.Server
{
    public sealed class Producer
    {
        private List<ISubscriber> Subscribers;

        public Producer()
        {
            Subscribers = new List<ISubscriber>();
        }

        public int GetCount()
        {
            return Subscribers.Count;
        }

        public Guid GetSubscriberById(Guid guid)
        {
            foreach (var sub in Subscribers)
            {
                if (sub.Id == guid)
                {
                    return sub.Id;
                }
            }
            return Guid.Empty;
        }

        public void Post(IMessage message)
        {
            foreach (Subscriber subscriber in Subscribers)
            {
                if (subscriber.SubscribedCode == message.ThemeCode)
                {
                    subscriber.Pull(message);
                }
            }
        }

        public void ShowActiveSubscribers()
        {
            foreach(var sub in Subscribers)
            {
                Console.WriteLine($"{sub.Id} connected, he subscribed to get messages with {sub.SubscribedCode}.");
            }
        }

        public void Subscribe(ISubscriber subscriber)
        {
            Subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            for (int i = 0; i < Subscribers.Count; i++)
            {
                if (subscriber.Id == Subscribers[i].Id)
                {
                    Subscribers.Remove(Subscribers[i]);
                    return;
                }
            }
        }        
    }
}
