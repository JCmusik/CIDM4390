using System;

namespace MessagePrinter
{
    public class MessagePrintingService
    {
        private string Message { get; set; }

        public MessagePrintingService() { }
        public MessagePrintingService(string message)
        {
            Message = message;
        }
        public void PrintMessage()
        {
            Console.WriteLine(this.Message);
        }
    }
}
