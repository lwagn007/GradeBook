using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Grades
{
    //Classes and Objects Section 2
    public class GradeBook : GradeTracker
    {
        protected List<float> _grades;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExisitingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                _name = value;
            }
        }

        //can use @ in front of cSharp key words in order to use it as a variable name but should try to utilize non keyword associated variable names.
        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < _grades.Count; i++)
            {
                destination.WriteLine(_grades[i]);
            }

            //write grades in reverse order
            //for (int i = grades.Count; i>0; i--)
            //{
            //   destination.WriteLine(grades[i-1]);
            //}
        }

        //events are based on delegates being an event it can only allow += or -= for delegate assignment
        //event convention == passes along two parameters. first parameter is the sender of the event the second parameter is all the info about the event
        public event NameChangedDelegate NameChanged;

        public GradeBook()
        {
            _grades = new List<float>();
            _name = "Empty";
        }

        public override void AddGrade(float grade)
        {
            _grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / _grades.Count;
            return stats;
        }

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }
    }
}