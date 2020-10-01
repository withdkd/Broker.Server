using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Server
{
    public sealed class Subscriber : ISubscriber
    {
        public Guid Id { get; set; }
        public int SubscribedCode { get; set; }
        private List<IMessage> Messages;

        public Subscriber()
        {
            Id = Guid.NewGuid();
            Messages = new List<IMessage>();
            SubscribedCode = -1;
        }

        public void Pull(IMessage message)
        {
            Messages.Add(message);
        }

        public void PrintAllMessages()
        {
			Console.WriteLine($"---Info about subscriber.---\nId = {Id}\tSubscribedCode = {SubscribedCode}\n");
            for (int i = 0; i < Messages.Count; i++)
            {
                Console.WriteLine($"#{i} We were receive next message: {Messages[i].PostedMessage}\tThemeCode = {Messages[i].ThemeCode}");
            }
        }

        //Не знаю как быть с необходимостью реализации интерфейсных методов. По логике класс Subscriber
        //должен реализовывать интерфейс ISubscriber, но эти методы ему не нужны, так как они реализованы 
        //в классе Producer, экземпляр которого имеет доступ к приватному списку активных пользователей, 
        //недоступному извне.
        public void Subscribe(ISubscriber subscriber)
        {
			
        }
        public void Unsubscribe(ISubscriber subscriber)
        {

        }
    }
}
