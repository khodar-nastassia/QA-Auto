using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class ValidDate
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public ValidDate(int year, int month)
        {
            Year = year;
            Month = month;
        }
        public override string ToString()
        {
            return Month + "/" + Year;

        }

    }
}
