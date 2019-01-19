using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Grades
{
    public class NameChangedEventArgs : EventArgs
    {
        public string ExisitingName { get; set; }
        public string NewName { get; set; }
    }
}
