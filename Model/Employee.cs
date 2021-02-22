using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo
{
    public enum ComparisonStateEnum
    {
        EQUAL,
        DIFFERENT,
        REFERENCE
    }

    internal class Employee
    {
        public string EmployeeInfo;

        public ComparisonStateEnum ComparisonState;

        public override string ToString()
        {
            if (EmployeeInfo != null)
            {
                return EmployeeInfo;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
