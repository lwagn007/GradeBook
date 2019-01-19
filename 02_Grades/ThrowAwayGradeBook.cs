using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            float lowest = float.MaxValue;
            foreach (float grade in _grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            _grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}
