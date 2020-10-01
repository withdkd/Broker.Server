using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Server
{
    //Не уверен, правильно ли я понял задание, но привожу реализацию того, как я это увидел.
    class Program
    {
        static void Main(string[] args)
        {
            Producer producer = new Producer();
            Subscriber subscriber1 = new Subscriber();
            Subscriber subscriber2 = new Subscriber();
			Subscriber subscriber3 = new Subscriber();
			
			//Подписываем подписчиков на случайный код сообщений (3 вида, но каждый подписывается на один код темы).
			Random rnd = new Random();
			int code = rnd.Next(0, 3);
			subscriber1.SubscribedCode = code;
			producer.Subscribe(subscriber1);
			
			code = rnd.Next(0, 3);
			subscriber2.SubscribedCode = code;
			producer.Subscribe(subscriber2);
			
			code = rnd.Next(0, 3);
			subscriber3.SubscribedCode = code;
			producer.Subscribe(subscriber3);
			
			//Создаем случайные сообщения от брокера.
            for (int i = 0; i < 100; i++)
            {
                code = rnd.Next(0, 3);
                producer.Post(new Message(code, $"{i}_message with code {code}"));
            }
			
			try 
			{
                //Показываем список активных подписчиков у брокера и проверяем функцию отписки от уведомлений.
                producer.ShowActiveSubscribers();
                Console.WriteLine("Select user, which unsubscribe from broker (type 1-3) or type 0 to continue.");
                int sub = Int32.Parse(Console.ReadLine());
                switch (sub)
                {
                    case 0:
                        break;
                    case 1:
                        producer.Unsubscribe(subscriber1);
                        subscriber1.SubscribedCode = -1;
                        break;
                    case 2:
                        producer.Unsubscribe(subscriber2);
                        subscriber2.SubscribedCode = -1; 
                        break;
                    case 3:
                        producer.Unsubscribe(subscriber3);
                        subscriber3.SubscribedCode = -1;
                        break;
                    default:
                        break;
                }
                if (sub > 0 && sub < 4)
                {
                    producer.ShowActiveSubscribers();
                }
                //Ручная проверка того, как подписчики получали сообщения нужного им кода темы.
                while (true)
				{
					Console.WriteLine("Select subscriber by number (1-3) or type 0 for exit");
					sub = Int32.Parse(Console.ReadLine());
					if (sub == 0)
					{
                        break;
					}
					Console.WriteLine($"Now showing messages for {sub} subscriber");
					switch (sub)
					{
						case 1:
							subscriber1.PrintAllMessages();
							break;
						case 2:
							subscriber2.PrintAllMessages();
							break;
						case 3:
							subscriber3.PrintAllMessages();
							break;
						default:
							break;
					}
					Console.ReadKey();
				}
				Console.WriteLine("Press any key for exit");
				Console.ReadKey();
			
			}
			catch (Exception ex) 
			{
                Console.WriteLine(ex.Message);
                Console.ReadKey();
			}
        }
    }
}
