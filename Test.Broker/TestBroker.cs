using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Broker.Server;

namespace Test.Broker
{
    [TestClass]
    public class TestBroker
    {
        [TestMethod]
        public void TestSubscribe()
        {
            Producer producer = new Producer();
            Subscriber subscriber = new Subscriber();
            subscriber.SubscribedCode = 1;
            int actual = producer.GetCount();
            producer.Subscribe(subscriber);
            int expected = producer.GetCount() - 1;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestUnsubscribe()
        {
            Producer producer = new Producer();
            Subscriber subscriber1 = new Subscriber();
            subscriber1.SubscribedCode = 1;
            Subscriber subscriber2 = new Subscriber();
            subscriber2.SubscribedCode = 2;
            producer.Subscribe(subscriber1);
            producer.Subscribe(subscriber2);
            Guid actual = subscriber1.Id;
            producer.Unsubscribe(subscriber1);
            Guid expected = producer.GetSubscriberById(subscriber1.Id);
            Assert.AreNotEqual(actual, expected);
        }
    }
}
