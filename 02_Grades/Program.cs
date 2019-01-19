using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Grades
{
    //Classes and Objects Section 2
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            //program will throw exception if line below is uncommented.
            //book.Name = null;
            GetBookName(book);
            AddGradeToList(book);
            SaveGradesToFile(book);
            WriteResultsToConsole(book);
            //book.WriteGrades(Console.Out);
        }

        private static IGradeTracker CreateGradeBook()
        {
            //abstract classes can not be instantiated. It must be a concrete object
            return new ThrowAwayGradeBook();
        }

        private static void WriteResultsToConsole(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average Grade", stats.AverageGrade);
                                        //casting
            WriteResult("Highest Grade", (int)stats.HighestGrade);
            WriteResult("Lowest Grade", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
            Console.ReadKey();
        }

        private static void SaveGradesToFile(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGradeToList(IGradeTracker book)
        {
            book.AddGrade(91f);
            book.AddGrade(89.5f);
            book.AddGrade(75f);
        }

        private static void GetBookName(IGradeTracker book)
        {

            //try blocks can have multiple catch statements but only one catch block will fire if hit. Ordered by most specific catch exception to least specific.
            try
            {
                Console.WriteLine("Enter a gradebook name...");
                book.Name = Console.ReadLine();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Method Overloading
        //static void WriteResult(string description, int result)
        //{
        //    Console.WriteLine(description + ": " + result);
        //}

        static void WriteResult(string description, float result)
        {
            //string formatting
            Console.WriteLine("{0}: {1}", description, result);
            //string literal 
            //Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        //delegates are interesting. Point to multiple methods based on a event or determined variable change. Look at setter in Gradebook. 
        //book.NameChanged += new NameChangedDelegate(OnNameChanged);
        //book.NameChanged += new NameChangedDelegate(OnNameChangedTwo);

        //syntax for delegate can also be as below
        //book.NameChanged += OnNameChanged;
        //book.NameChanged += OnNameChangedTwo;

        //book.Name = "Merlin's Grade Book";
        //book.Name = "This is interesting...";
        //Event Method
        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.ExisitingName} to {args.NewName}.");
        //}

        //Second Event Method
        //static void OnNameChangedTwo(string existingName, string newName)
        //{
        //    Console.WriteLine("***");
        //}
    }
}