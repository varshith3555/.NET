using System;

namespace MyConsoleApp.Day4
{
    /// <summary>
    /// class Visitor in which i have created constructors(default, parameterized(single, double, triple)) and accessed through the main class
    /// </summary>
    public class Visitor
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Requirement { get; set; }
        public string LogHistory { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Visitor()
        {
            LogHistory += $" Object is created at {DateTime.Now.ToString()} \n";
        }
        /// <summary>
        /// constructor with only single parameter
        /// </summary>
        /// <param name="id"></param>
        public Visitor(int id) : this() 
        {
            this.ID = id;
            LogHistory += $" ID is created at {DateTime.Now.ToString()} {Environment.NewLine}";
        }
        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Visitor(int id, string name) : this(id)
        {
            //this.ID = id;
            this.Name = name;
           
            /// Validate the name value and Convert the name to lowercase and check if name contains "capp"
            if (name.ToLower().Contains("capp"))
                /// This stops object creation and sends an error message
                throw new ArgumentException("Change the name");

            LogHistory += $" Name is created at {DateTime.Now.ToString()} {Environment.NewLine}";
        }
        /// <summary>
        /// constructor with three parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="requirement"></param>
        public Visitor(int id, string name, string requirement) : this(id, name)
        {
            //this.ID = id;
            //this.Name = name;
            this.Requirement = requirement;

            LogHistory += $" Requirement is created at {DateTime.Now.ToString()} {Environment.NewLine}";
        }


    }
    public class Constructor
    {
        public static void Main(string[] args)
        {
            /// <summary>
            /// here in this object, it will call the constructor based on the initialization
            /// </summary>
            try
            {
                Visitor visitor = new Visitor(12201442, "Varshith", "PC");
                Console.WriteLine($"ID: {visitor.ID}\nName: {visitor.Name}\nRequirement: {visitor.Requirement}");
                Console.WriteLine($"Log History: \n {visitor.LogHistory}");
            }
            catch (Exception e)
            {
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}