using System;

namespace Broker.Server
{
    public sealed class Message : IMessage
    {
        public Message(int code, string message)
        {
            ThemeCode = code;
            PostedMessage = message;
            PostedAt = DateTime.Now;
        }
        public int ThemeCode { get; set; }
        public string PostedMessage { get; set; }
        public DateTime PostedAt { get; set; }

    }
}
