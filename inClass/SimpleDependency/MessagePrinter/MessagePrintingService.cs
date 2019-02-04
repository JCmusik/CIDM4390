using System;

namespace MessagePrinter
{
    public class MessagePrintingService : IMessagePrinter
    {
        private string Message { get; set; }

        public MessagePrintingService() { }
        public MessagePrintingService(string message)
        {
            Message = message;
        }

        public void PrintMessage(string message)
        {
            Message = message;
            Console.WriteLine(this.Message);
        }
    }
}
