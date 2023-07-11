using System;
using System.Reflection;

namespace HelloCS
{
    class Hello_world
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\televisions\sony\bravia.txt";
            string test = "Test";


            Assembly? assembly = Assembly.GetEntryAssembly(); 
            if (assembly == null) return; // loop through the assemblies that this app references
            foreach (AssemblyName name in assembly.GetReferencedAssemblies()) { 
                // load the assembly so we can read its details
                Assembly ass = Assembly.Load(name); 
                // declare a variable to count the number of methods
                int methodCount = 0; 
                // loop through all the types in the assembly
                foreach (TypeInfo t in ass.DefinedTypes) { 
                // add up the counts of methods
                methodCount += t.GetMethods().Count(); } 
                // output the count of types and their methods
                Console.WriteLine( "{0:N0} types with {1:N0} methods in {2} assembly.", arg0: ass.DefinedTypes.Count(), arg1: methodCount, arg2: name.Name); }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("filepath {0:N0}", arg0: filePath);
            Console.WriteLine("test {0:N0}", arg0: test);

            Console.WriteLine("Using doubles:"); 
            double a = 0.1; 
            double b = 0.2; 
            if (a + b == 0.3) { 
                Console.WriteLine($"{a} + {b} equals {0.3}"); } 
            else { 
                Console.WriteLine($"{a} + {b} does NOT equal {0.3}"); }


        }
    }
}
