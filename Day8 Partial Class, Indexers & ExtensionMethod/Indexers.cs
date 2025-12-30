using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

// An Indexer allows an object of a class to be accessed like an array using [ ]. 
// we need Indexers :- Because sometimes a class contains a collection of data and we want to: 1)Access that data directly using index. 2)Make the class behave like an array
namespace MyConsoleApp.Day8
{
    public class Indexers
    {
        private string[] values = new string[2];

        // Indexer
        public string this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }
    }
    class IndexersMain
    {
        public static void Main()
        {
            Indexers arr = new Indexers();
            arr[0] = "C";
            arr[1] = "c#";
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);
        }
    }
}
