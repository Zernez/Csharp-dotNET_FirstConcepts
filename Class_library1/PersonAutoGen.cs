using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Packt.Shared
{
    public partial class Person
    {
        //With "required" word in declaration, in instantation is mandatory to "set" the property
        public string FavoriteIceCream { get; set; }

        // a property defined using C# 1 - 5 syntax
        public string Origin { get { return $"{Name} was born on {HomePlanet}"; } } 
        // two properties defined using C# 6+ lambda expression body syntax
        public string Greeting => $"{Name} says 'Hello!'"; 
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        private string favoritePrimaryColor; 
        public string FavoritePrimaryColor
        {
            get { return favoritePrimaryColor; }
            
            set
            {
                switch (value.ToLower())
                {
                    case "red": 
                    case "green": 
                    case "blue": favoritePrimaryColor = value; break;
                    default:
                        throw new System.ArgumentException($"{value} is not a primary color. " + "Choose from: red, green, blue.");
                }
            }
        }
        // indexers
        public Person this[int index] {
            get { return Children[index]; }
                // pass on to the List<T> indexer
            set { Children[index] = value; } } 
    }
}
