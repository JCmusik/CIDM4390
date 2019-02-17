### Solid principles

Up to this point, you've probably put most of your logic in the `Program.cs`file.  This is where the application first starts up and where your code did what you programmed it to do.  Although this has worked for simple applications, this will hinder your success as a coder for larger projects.  Code written like this is hard to read and maintain and does not lend itself to coding within a team.  Your projects should be coded in a way that allows for change.  The Solid principles go hand in hand and work together.  These principles will guide you in how you should think about writing code that is loosely coupled and depends on abstractions.  The first principle in Solid is called Single Responsibilty and is defined below.

<dl>
<dt>Single Responsibility</dt>
<dd>A class should have one, and only one, reason to change.</dd>
</dl>

In this simple console project, I will use a simple example to demonstrate how this principle is applied.
The `Program.cs` file looks like this:
```csharp
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

```
As you can see there are several things that the Program class is currently responsible for.  Displaying messages, getting user input, validating user input, and creating a new user.  The Single Reposibility Principle is violated because the Program class is responsible for more than one thing.  There is more than one reason to change it. Let's seperate these responsibilites one at a time.

## Displaying messages
Since there are several times that messages are being displayed, why don't we make a class that handles that responsibilty and call it `MessagePrinter.cs` and fill with the contents below.
```csharp 
using System;

namespace Solid
{
    public class MessagePrinter
    {
        public void InitialWelcome()
        {
            Console.WriteLine("Welcome to this single responsiblity app");
        }
        public void GetUserFirstName()
        {
            Console.Write("Please enter your first name ");
        }
        public void GetUserLastName()
        {
            Console.Write("Please enter your last name ");
        }

        public void InvalidDataMessage()
        {
            Console.WriteLine("Please enter valid info");
        }

        public void WelcomeUser(User user)
        {
            Console.WriteLine($"Welcome { user }");
        }
    }
}
```
Some would say that this MessagePrinter class is already too large and would need to seperate each one of these into their own class.  That would probably be better if this app was much larger, but you could argue that this class is repsonsible for one thing and that is displaying messages.

Now we'll need to refactor the `Program.cs` file to accomodate this change.
### Change this line of code
```csharp
    Console.WriteLine("Welcome to this single responsiblity app");
```
### To this
```csharp
    var message = new MessagePrinter();
    message.InitialWelcome();

```
Although I've added a new responsibilty to the `Program.cs` file, which is the instantiation the MessagePrinter class, we'll refactor this later as well.  Hopefully you can see that the Program class is not responsible for displaying the message, only calling the class that does.  Also notice that we don't know the implementation details of the `InitialWelcome`, we just know that we need an initial message.  Let's locate the other places where we need a message displayed.

```csharp
    Console.Write("Please enter your first name ");

    Console.Write("Please enter your last name ");

    Console.WriteLine("Please enter valid info");

    Console.WriteLine($"Welcome { user }");
```

Let's change the lines of code so that we can shift the responsibilty of displaying messages to the class that is responsible for it.  Change those lines of code to the following respectively:

```csharp
    message.GetUserFirstName();

    message.GetUserLastName();

    message.InvalidDataMessage();

    message.WelcomeUser(user);
```

The app runs the same as before but now `Program.cs` is not responsible for displaying messages.

## Validating User

Next on our list is validating the user.  Let's create a file  `UserValidator.cs` and place the contents below:
```csharp
using System;

namespace Solid
{
    public class UserValidator
    {
        public bool isUserValid(bool isValid, string fname, string lname)
        {

            while (isValid == false)
            {
                Console.WriteLine(); // creates blank line for readablitiy

                // Validate user
                if (!string.IsNullOrWhiteSpace(fname) && !string.IsNullOrWhiteSpace(lname))
                    isValid = true;
                else
                    return false;

            }
            return true;
        }
    }
}
```
Just before the while loop begins, add this line so that we can have access to the UserValidator class. (we'll refactor this later as well)
```csharp
    var validator = new UserValidator();
```

### Replace these lines of code,
```csharp
    if (!string.IsNullOrWhiteSpace(fName) && !string.IsNullOrWhiteSpace(lName))
        isValid = true;
    else
        message.InvalidDataMessage();
```
### With these
```csharp
    isValid = validator.isUserValid(isValid, fName, lName);

    if (!isValid)
        message.InvalidDataMessage();
```

Now the Program class has moved the responsibilty of validating the user data into the UserValidator class.  

Lets refactor the code once again and remove another responsibilty and place it into its own class.  We are going to be using a Simple Factory Pattern to handle instantiating objects.  Later on we'll discuss Dependency Injection which is better suited for the MVC architecture.

Create a class called `Factory.cs` and add the following code:
```csharp
namespace Solid
{
    public class Factory
    {
        public static MessagePrinter GetMessages()
        {
            return new MessagePrinter();
        }

        public static UserValidator ValidateUser()
        {
            return new UserValidator();
        }

        public static User GetUser(string fname, string lName)
        {
            return new User(fname, lName);
        }
    }
}
```
This Factory will be using static classes so there we won't need to instantiate this class to use it's methods.

Let's locate the places where `Program.cs` is instantiating classes.  I've often heard seasoned coders say, "new is glue".  This means that when you see the keyword new being used you have now created a dependency.  Earlier I mentioned we want loose coupling in our code and depend on abstractions so using the new keyword is a code smell.

Now refactor the following lines in the `Program.cs` file
```csharp
    var message = new MessagePrinter();

    var validator = new UserValidator();

    var user = new User(fName, lName);
```

to this
```csharp
    var message = Factory.GetMessages();

    var validator = Factory.ValidateUser();

    var user = Factory.GetUser(fName, lName); 
```

## Conclusion

Your application runs as it did when we first started, however your Program class has one repsonsibility which is to call on other classes to perform their single responsiblity.  Now consider someone reading your code and they want to see the implementation details of how you are validating user data.  They can `ctrl+click [Windows]` or `command+click [Mac]` on the `ValidateUser()` in `Program.cs` be taken to the the occurence of this method in `UserValidator.cs` class to view the implementation.
