using System;
using System.Reflection;
using System.Xml;
using static System.Console;
using System.Globalization;



namespace HelloCS
{
    class Hello_world
    {
        static void Main(string[] args)
        {
            WriteLine($"There are {args.Length} arguments.");

            foreach (string arg in args)
            {
                WriteLine(arg);
            }

            if (args.Length < 3)
            {
                WriteLine("You must specify two colors and a cursor size, e.g.");
                WriteLine("dotnet run red yellow 10");
                return; // stop running
            }

            ForegroundColor = (ConsoleColor)Enum.Parse(
              enumType: typeof(ConsoleColor),
              value: args[0],
              ignoreCase: true);

            BackgroundColor = (ConsoleColor)Enum.Parse(
              enumType: typeof(ConsoleColor),
              value: args[1],
              ignoreCase: true);

            try
            {
                WriteLine("Pre-catch");
                CursorSize = int.Parse(args[2]);
            }
            catch (PlatformNotSupportedException)
            {
                WriteLine("The current platform does not support changing the size of the cursor.");
            }

            if (OperatingSystem.IsWindows())
            {
                WriteLine("Windows OS!");
                // execute code that only works on Windows
            }
            else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10))
            {
                // execute code that only works on Windows 10 or later
            }
            else if (OperatingSystem.IsIOSVersionAtLeast(major: 14, minor: 5))
            {
                // execute code that only works on iOS 14.5 or later
            }
            else if (OperatingSystem.IsBrowser())
            {
                // execute code that only works in the browser with Blazor
            }

            object height = 1.88; // storing a double in an object
            object name = "Amir"; // storing a string in an object
            Console.WriteLine($"{name} is {height} metres tall.");
            //int length1 = name.Length; //gives compile error!
            int length2 = ((string)name).Length;
            // tell compiler it is a string
            Console.WriteLine($"{name} has {length2} characters.");

            var population = 66_000_000; // 66 million in UK
            var weight = 1.88F; // in kilograms
            var price = 4.99M; // in pounds sterling
            var fruit = "Apples"; // strings use double-quotes
            var letter = 'Z'; // chars use single-quotes
            var happy = true; // Booleans have value of true or false

            var xml1 = new XmlDocument(); 
            XmlDocument xml2 = new XmlDocument(); // bad use of var because we cannot tell the type, so
                                                  // we should use a specific type declaration as shown in the second statement
            var file1 = File.CreateText("something1.txt"); 
            StreamWriter file2 = File.CreateText("something2.txt"); //good representation because of visible type

            int numberOfApples = 12;
            decimal pricePerApple = 0.35M;

            WriteLine(
                format: "{0} apples costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples);

            string formatted = string.Format(
                format: "{0} apples costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples);

            //WriteToFile(formatted); // writes the string into a file
            Console.WriteLine(pricePerApple.ToString("C3", CultureInfo.CreateSpecificCulture("da-DK")));
            CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
            Console.WriteLine(pricePerApple.ToString("C3", culture));
            WriteLine($"{numberOfApples} apples costs {string.Format(culture, "{0:C}", pricePerApple * numberOfApples)}");

            Write("Type your first name and press ENTER: "); 
            string? firstName = ReadLine(); Write("Type your age and press ENTER: "); 
            string? age = ReadLine(); WriteLine($"Hello {firstName}, you look good for {age}.");

            Write("Press any key combination: ");
            ConsoleKeyInfo key = ReadKey(); 
            WriteLine(); 
            WriteLine("Key: {0}, Char: {1}, Modifiers: {2}", arg0: key.Key, arg1: key.KeyChar, arg2: key.Modifiers);
        }
    }
}


