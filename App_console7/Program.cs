using Packt.Shared;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Globalization;


// var bob = new Person(); // C# 1.0 or later
Person bob = new(); // C# 9.0 or later WriteLine(bob.ToString());
WriteLine(bob.ToString());

bob.Name = "Bob Smith";
bob.DateOfBirth = new DateTime(1965, 12, 22); // C# 1.0 or later
WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}", arg0: bob.Name, arg1: bob.DateOfBirth);

Person alice = new(){
    Name = "Alice Jones",
    DateOfBirth = new(1998, 3, 7)};
WriteLine(format: "{0} was born on {1:dd MMM yy}", arg0: alice.Name, arg1: alice.DateOfBirth);

bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia; 
WriteLine(format: "{0}'s favorite wonder is {1}. Its integer is {2}.", arg0: bob.Name, arg1: bob.FavoriteAncientWonder, arg2: (int)bob.FavoriteAncientWonder);

bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus; //bob.BucketList = (WondersOfTheAncientWorld)18; 
WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

bob.Children.Add(new Person { Name = "Alfred" }); // C# 3.0 and later
bob.Children.Add(new() { Name = "Zoe" }); // C# 9.0 and later
WriteLine( $"{bob.Name} has {bob.Children.Count} children:"); 
for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++) { 
    WriteLine($" {bob.Children[childIndex].Name}"); }

BankAccount.InterestRate = 0.012M; // store a shared value

BankAccount jonesAccount = new(); // C# 9.0 and later
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;

Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB", false);

WriteLine(format: "{0} earned {1:C} interest.",
  arg0: jonesAccount.AccountName,
  arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;

Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK", false);

WriteLine(format: "{0} earned {1:C} interest.",
  arg0: gerrierAccount.AccountName,
  arg1: gerrierAccount.Balance * BankAccount.InterestRate);

WriteLine($"{bob.Name} is a {Person.Species}");
WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

Person blankPerson = new(); 
WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.", arg0: blankPerson.Name, arg1: blankPerson.HomePlanet, arg2: blankPerson.Instantiated);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars"); 
WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.", arg0: gunny.Name, arg1: gunny.HomePlanet, arg2: gunny.Instantiated);

bob.WriteToConsole(); 
WriteLine(bob.GetOrigin());
var fruitNamed = bob.GetNamedFruit(); WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

(string, int) fruit = bob.GetFruit(); WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

(string TheName, int TheNumber) tupleWithNamedFields = bob.GetNamedFruit();
(string name, int number) = bob.GetNamedFruit();

var thing1 = ("Neville", 4); 
WriteLine($"{thing1.Item1} has {thing1.Item2} children."); 
var thing2 = (bob.Name, bob.Children.Count); WriteLine($"{thing2.Name} has {thing2.Count} children.");

(string fruitName, int fruitNumber) = bob.GetFruit(); WriteLine($"Deconstructed:{fruitName}, {fruitNumber}");

// Deconstructing a Person
var (name1, dob1) = bob; 
WriteLine($"Deconstructed: {name1}, {dob1}"); 
var (name2, dob2, fav2) = bob; 
WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

WriteLine(bob.SayHello()); 
WriteLine(bob.SayHello("Emily"));

WriteLine(bob.OptionalParameters());
// Is possible to swap
WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));

int a = 10; int b = 20; int c = 30; 
WriteLine($"Before: a = {a}, b = {b}, c = {c}"); 
bob.PassingParameters(a, ref b, out c); 
WriteLine($"After: a = {a}, b = {b}, c = {c}");

int d = 10; int e = 20; 
WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!"); // simplified C# 7.0 or later syntax for the out parameter
bob.PassingParameters(d, ref e, out int f); 
WriteLine($"After: d = {d}, e = {e}, f = {f}");

public class Person : object{
    public string Name; 
    public DateTime DateOfBirth;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = new();
    public const string Species = "Homo Sapien";
    // read-only fields
    public readonly string HomePlanet = "Earth"; 
    public readonly DateTime Instantiated; // constructors
    public Person() { // set default values for fields
        Name = "Unknown"; Instantiated = DateTime.Now;
    }
    public Person(string initialName, string homePlanet) { 
        Name = initialName; 
        HomePlanet = homePlanet; 
        Instantiated = DateTime.Now;
    }

    // methods
    public (string Name, int Number) GetNamedFruit() { return (Name: "Apples", Number: 5); }
    public (string, int) GetFruit() { return ("Apples", 5); }
    public void WriteToConsole() { WriteLine($"{Name} was born on a {DateOfBirth:dddd}."); } 
    public string GetOrigin() { return $"{Name} was born on {HomePlanet}."; }

    // deconstructors
    public void Deconstruct(out string name, out DateTime dob) { name = Name; dob = DateOfBirth; }
    public void Deconstruct(out string name, out DateTime dob, out WondersOfTheAncientWorld fav) { name = Name; dob = DateOfBirth; fav = FavoriteAncientWonder; }

    public string SayHello() { return $"{Name} says 'Hello!'"; }
    public string SayHello(string name) { return $"{Name} says 'Hello {name}!'"; }

    public string OptionalParameters(string command = "Run!", double number = 0.0, bool active = true) { 
        return string.Format(format: "command is {0}, number is {1}, active is {2}", arg0: command, arg1: number, arg2: active); 
    }

    public void PassingParameters(int x, ref int y, out int z)
    { // out parameters cannot have a default // AND must be initialized inside the method
      z = 99; 
      // increment each parameter
      x++; y++; z++; 
    }
}

