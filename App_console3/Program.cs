using static System.Console;
using static System.Convert;

namespace TypesCS
{
    class Types
    {
        static void Main(string[] args)
        {
            WriteLine("--------------------------------------------------------------------------");
            WriteLine("Type    Byte(s) of memory               Min                            Max");
            WriteLine("--------------------------------------------------------------------------");
            WriteLine($"sbyte   {sizeof(sbyte),-4} {sbyte.MinValue,30} {sbyte.MaxValue,30}");
            WriteLine($"byte    {sizeof(byte),-4} {byte.MinValue,30} {byte.MaxValue,30}");
            WriteLine($"short   {sizeof(short),-4} {short.MinValue,30} {short.MaxValue,30}");
            WriteLine($"ushort  {sizeof(ushort),-4} {ushort.MinValue,30} {ushort.MaxValue,30}");
            WriteLine($"int     {sizeof(int),-4} {int.MinValue,30} {int.MaxValue,30}");
            WriteLine($"uint    {sizeof(uint),-4} {uint.MinValue,30} {uint.MaxValue,30}");
            WriteLine($"long    {sizeof(long),-4} {long.MinValue,30} {long.MaxValue,30}");
            WriteLine($"ulong   {sizeof(ulong),-4} {ulong.MinValue,30} {ulong.MaxValue,30}");
            WriteLine($"float   {sizeof(float),-4} {float.MinValue,30} {float.MaxValue,30}");
            WriteLine($"double  {sizeof(double),-4} {double.MinValue,30} {double.MaxValue,30}");
            WriteLine($"decimal {sizeof(decimal),-4} {decimal.MinValue,30} {decimal.MaxValue,30}");
            WriteLine("--------------------------------------------------------------------------");

            bool a = true; bool b = false; 
            WriteLine($"AND | a | b "); 
            WriteLine($"a | {a & a,-5} | {a & b,-5} "); 
            WriteLine($"b | {b & a,-5} | {b & b,-5} "); 
            WriteLine(); WriteLine($"OR | a | b "); 
            WriteLine($"a | {a | a,-5} | {a | b,-5} "); 
            WriteLine($"b | {b | a,-5} | {b | b,-5} "); 
            WriteLine(); WriteLine($"XOR | a | b "); 
            WriteLine($"a | {a ^ a,-5} | {a ^ b,-5} "); 
            WriteLine($"b | {b ^ a,-5} | {b ^ b,-5} ");

            static bool DoStuff() { WriteLine("I am doing some stuff."); return true; }

            WriteLine(); 
            WriteLine($"a & DoStuff() = {a & DoStuff()}"); 
            WriteLine($"b & DoStuff() = {b & DoStuff()}");

            WriteLine($"a && DoStuff() = {a && DoStuff()}"); 
            WriteLine($"b && DoStuff() = {b && DoStuff()}");


            int a2 = 10; // 00001010
            int b2 = 6; // 00000110
            WriteLine($"a = {a2}"); 
            WriteLine($"b = {b2}"); 
            WriteLine($"a & b = {a2 & b2}"); // 2-bit column only
            WriteLine($"a | b = {a2 | b2}"); // 8, 4, and 2-bit columns
            WriteLine($"a ^ b = {a2 ^ b2}"); // 8 and 4-bit columns

            WriteLine($"a << 3 = {a2 << 3}"); // multiply a by 8
            WriteLine($"a * 8 = {a2 * 8}"); // 00000011 right-shift b by one bit column
            WriteLine($"b >> 1 = {b2 >> 1}");

            static string ToBinaryString(int value) 
            { return Convert.ToString(value, toBase: 2).PadLeft(8, '0'); }

            WriteLine(); WriteLine("Outputting integers as binary:"); 
            WriteLine($"a = {ToBinaryString(a2)}");
            WriteLine($"b = {ToBinaryString(b2)}"); 
            WriteLine($"a & b = {ToBinaryString(a2 & b2)}");
            WriteLine($"a | b = {ToBinaryString(a2 | b2)}"); 
            WriteLine($"a ^ b = {ToBinaryString(a2 ^ b2)}");

            Write("Press R for read-only or W for writeable: "); 
            ConsoleKeyInfo key = ReadKey(); WriteLine(); 
            Stream? s;
            string path = @"C:\Users\User\Desktop";

            if (key.Key == ConsoleKey.R) 
            { s = File.Open(Path.Combine(path, "GIT_token.txt"), FileMode.OpenOrCreate, FileAccess.Read); } 
            else 
            { s = File.Open(Path.Combine(path, "GIT_token.txt"), FileMode.OpenOrCreate, FileAccess.Write); }

            string message; switch (s)
            {
                case FileStream writeableFile when s.CanWrite: message = "The stream is a file that I can write to."; break;
                case FileStream readOnlyFile: message = "The stream is a read-only file."; break;
                case MemoryStream ms: message = "The stream is a memory address."; break;
                default: // always evaluated last despite its current position
                         message = "The stream is some other type."; break; 
                case null: message = "The stream is null."; break; } 
             WriteLine(message);

            string? password; // nullable type
            do { Write("Enter your password: "); 
                password = ReadLine(); } 
            while (password != "Pa$$w0rd"); 
            WriteLine("Correct!");

            string[] names = { "Adam", "Barry", "Charlie" }; 
            foreach (string name in names) 
            { WriteLine($"{name} has {name.Length} characters."); }

            long e = 10; int f = (int)e; 
            WriteLine($"e is {e:N0} and f is {f:N0}"); 
            e = long.MaxValue; f = (int)e; 
            WriteLine($"e is {e:N0} and f is {f:N0}");

            double[] doubles = new[] { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };

            foreach (double n in doubles) 
            { WriteLine(format: "Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}", 
                arg0: n, 
                arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero)); }

            int number = 12; 
            WriteLine(number.ToString()); 
            bool boolean = true; 
            WriteLine(boolean.ToString()); 
            DateTime now = DateTime.Now; 
            WriteLine(now.ToString()); 
            object me = new(); 
            WriteLine(me.ToString());

            // allocate array of 128 bytes
            byte[] binaryObject = new byte[128]; 
            // populate array with random bytes
            (new Random()).NextBytes(binaryObject);
            WriteLine("Binary Object as bytes:"); 
            for(int index = 0; index < binaryObject.Length; index++) 
            { Write($"{binaryObject[index]:X} "); } WriteLine(); 
            // convert to Base64 string and output as text
            string encoded = ToBase64String(binaryObject); 
            WriteLine($"Binary Object as Base64: {encoded}");

            WriteLine("Before parsing"); 
            Write("What is your age? "); 
            string? input = ReadLine(); 
            // or use "49" in a notebook
            try { int age = int.Parse(input); 
                WriteLine($"You are {age} years old."); } 
            catch { } WriteLine("After parsing");

            try
            {checked { int x = int.MaxValue - 1; 
             WriteLine($"Initial value: {x}"); 
             x++; 
             WriteLine($"After incrementing: {x}"); 
             x++; 
             WriteLine($"After incrementing: {x}"); 
             x++; 
             WriteLine($"After incrementing: {x}"); }
             } 
            catch (OverflowException) 
            { WriteLine("The code overflowed but I caught the exception."); }


        }
    }
}

