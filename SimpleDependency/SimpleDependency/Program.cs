using System;
using MessagePrinter;

namespace SimpleDependency
{
    class Program
    {
        static void Main(string[] args)
        {

            var service = new MessagePrintingService("Print from Message Printing Service");

            service.PrintMessage();

            Console.ReadLine();


        }
    }
}
