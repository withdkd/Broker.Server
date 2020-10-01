using System;

namespace Broker.Server
{
    public interface ISubscriber
    {
        Guid Id { get; set; }
		int SubscribedCode { get;set; }
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
    }
}