using static System.Console;
using static System.Convert;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;


namespace DebugCS
{
    class Types
    {

        static void Main(string[] args)
        {
            /// <summary> 
            /// Pass a 32-bit integer and it will be converted into its ordinal equivalent. 
            /// </summary> 
            /// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on. </param> 
            /// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on. </returns>
            static string CardinalToOrdinal(int number)
            {
                switch (number)
                {
                    // special cases for 11th to 13th
                    case 11: 
                    case 12: 
                    case 13: return $"{number}th"; 
                    default: int lastDigit = number % 10; 
                    string suffix = lastDigit 
                    switch { 1 => "st", 2 => "nd", 3 => "rd", _ => "th" }; 
                    return $"{number}{suffix}"; } }

            static void RunCardinalToOrdinal() { 
                for (int number = 1; number <= 40; number++) 
                { Write($"{CardinalToOrdinal(number)} "); }
                WriteLine(); 
                }

            RunCardinalToOrdinal();


            static int FibImperative(int term) { 
                if (term == 1) { return 0; } 
                else if (term == 2) { return 1; } 
                else { return FibImperative(term - 1) + FibImperative(term - 2); } 
            }

            static void RunFibImperative() { 
                for (int i = 1; i <= 30; i++) 
                { WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.", arg0: CardinalToOrdinal(i), arg1: FibImperative(term: i)); } }

            RunFibImperative();

            static int FibFunctional(int term) => term 
                switch { 1 => 0, 2 => 1, _ => FibFunctional(term - 1) + FibFunctional(term - 2) };

            static void RunFibFunctional() { 
                for (int i = 1; i <= 30; i++) {
                    WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.", arg0: CardinalToOrdinal(i), arg1: FibFunctional(term: i)); } }

            RunFibFunctional();

            // write to a text file in the project folder
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt"))));
            // Flush() on all listeners after writing
            Trace.AutoFlush = true;


            Debug.WriteLine("Debug says, I am watching!");
            Trace.WriteLine("Trace says, I am watching!");
            Debug.WriteLine("Debug says, I am watching!");

            ConfigurationBuilder builder = new();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            TraceSwitch ts = new(displayName: "PacktSwitch", description: "This switch is set via a JSON config.");
            configuration.GetSection("PacktSwitch").Bind(ts);
            Trace.WriteLineIf(ts.TraceError, "Trace error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
        }
    }
}

