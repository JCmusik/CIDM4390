using System;
using MessagePrinter;

namespace SimpleDependency
{
    class Program
    {
        static void Main(string[] args)
        {

            IMessagePrinter service = new MessagePrintingService();

            service.PrintMessage("Hello World");


        }
    }
}
