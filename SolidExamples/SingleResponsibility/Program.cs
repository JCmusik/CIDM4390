using System;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Welcome to this single responsiblity app");
            string fName = "";
            string lName = "";

            bool isValid = false;
            while (isValid == false)
            {
                Console.WriteLine();
                // Prompt user for input
                // Validate user
                // if not valid, prompt user to re-enter invalid info
                Console.Write("Please enter your first name ");
                fName = Console.ReadLine();
                Console.Write("Please enter your last name ");
                lName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(fName) && !string.IsNullOrWhiteSpace(lName))
                    isValid = true;
                else
                    Console.WriteLine("Please enter valid info");
            }

            // Create User
            var user = new User(fName, lName);

            // Display message to new user
            Console.WriteLine($"Welcome { user }");
        }
    }
}