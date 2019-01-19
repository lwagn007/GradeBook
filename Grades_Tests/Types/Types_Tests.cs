using _02_Grades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades_Tests.Types
{   [TestClass]
    public class Types_Tests
    {
        [TestMethod]
        public void UsingArrays()
        {
            //Collections are reference types
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1], 0.01);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            //Immutability
            string name = "arthur";
                    //creates a new string, doesn't change original variable unless variable set to new instance.
            name = name.ToUpper();

            Assert.AreEqual("ARTHUR", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            //Immutability
            DateTime date = new DateTime(2019, 1, 1);
                    //creates a new string, doesn't change original variable unless variable set to new instance.
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x); //Method won't change what value type x is.
            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book = new GradeBook();
            GradeBook bookTwo = book;

            GiveBookAName(bookTwo);
            Assert.AreEqual("A GradeBook", book.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name = "Adam";
            string nameTwo = "adam";

            bool result = string.Equals(name, nameTwo, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValues()
        {
            int xOne = 100;
            int xTwo = xOne;

            xOne = 4;
            Assert.AreNotEqual(xOne, xTwo);
        }

        [TestMethod]
        public void VariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "EFA's grade book";
            Assert.AreNotEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void SwitchOutput()
        {
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("Hello");
                    break;
                case 2:
                    Console.WriteLine("What you doing");
                    break;
                default:
                    Console.WriteLine("this is default");
                    break;
            }
        }

        public int AddTwoNumbers(int kung, int fu)
        {
            int spaghetti = kung + fu;
            return spaghetti;
        }
    }
}
